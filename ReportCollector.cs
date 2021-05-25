using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepCol_2
{
    public partial class ReportCollector : Form, IDisposable
    {
        public ReportCollector()
        {
            InitializeComponent();

            TypeFile.SelectedItem = "ALL";      
            
            tabNameBox.SelectedIndexChanged += tabNameBox_SelectedIndexChanged;

            // Загрузка настроек по парам [ключ]-[значение].
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
            if (allAppSettings.Count < 1) 
            {
                MessageBox.Show("Каталоги по умолчанию не заданы"); 
            }

            // Восстановление состояния:
            string sourceFolderStr = allAppSettings["sourcePath"];
            string destinationFolderStr = allAppSettings["destinationPath"];
            string configFilePath = allAppSettings["configFilePath"];

            sourceFolder.Text = sourceFolderStr;
            destinationFolder.Text = destinationFolderStr;
            textSettingPath.Text = configFilePath;

            // string configPath = "";           

            isClickButtonSelectAll = true;

            if (sourceFolder.Text != "")
            {               
                tempPath = sourceFolder.Text;

                string[] second = Directory.GetFiles(tempPath);

                for (int i = 0; i < second.Length; i++)
                {
                    fileList[i] = second[i];
                }

                filesPath = fileList;

                GetBooksSource(filesPath);
                //GetNameListWorkBooks(filesPath);
            }          
        }
        //OpenFileDialog openFileDialog = new OpenFileDialog();

        // Список листов книг
        string[] fileList = new string[100];

        // Список выбранных файлов
        string[] filesPath = new string[100];

        // Переменная для хранения пути к конечному файлу
        string fileNameFiished = "";

        //
        string pathFile = "";

        // Объявляем тип делегата
       public delegate ISheet[] ReportSheetDelegat(List<string> ListBook);

        // Переменная для хранения строки с названием листа
        string selectedStateTabName = "";

        //Переменная для хранения количества колонок
        int lastColumnSource = 0;

        //Флаг проверки нажатия кнопки для выбора каатлога-приемника
        bool isClickButtonUnloadFile = false;

        //Флаг проверки нажатия кнопки для выбора каатлога-источника
        bool isClickButtonSelectAll = false;

        // строка содержащая путь к каталогу - источнику
        string tempPath = "";

        //
        // ISheet[] oSheetList = new ISheet[] { };
        ISheet[] sheets = new ISheet[500];
        //===================   Метод формирования итогового файла   ==================
        /// <summary>
        /// Метод вставки данных в книгу
        /// </summary>
        /// <param name="FileNamesSelect"> Список выбранных файлов</param>
        /// <param name="selectedState">Выбранный тип файла</param>
        #region ImportExcelHSSF_2(string[] FileNamesSelect, string selectedState)
        private void ImportExcelHSSF_2(string[] FileNamesSelect, string selectedState)
        {
            //----------- книга - приемник -----------------
            var newbook = new XSSFWorkbook();

            ISheet sheetBook = newbook.CreateSheet(tabNameBox.SelectedItem.ToString());

            IRow rowsheet = sheetBook.CreateRow(0);

            ICell cell = rowsheet.CreateCell(0);

            ICellStyle cellStyle = newbook.CreateCellStyle();

            //----------- счетчик строк в листе   ------------------
            int countRow = 0;

            int CountRowNull = 0;
            //--- цикл перебора всех листов с нужным названием ------
            for (var nextsheet = 0; nextsheet < sheets.Length; nextsheet++)
            {               
                if (sheets[nextsheet] == null)
                    break;
                else
                if (sheets[nextsheet].SheetName == tabNameBox.SelectedItem.ToString())
                {
                    // проверка на наличие данных в листе
                    // если лист не пустой то вставляем со смещением countRow
                    if (sheetBook.GetRow(sheetBook.LastRowNum) != sheetBook.GetRow(sheetBook.FirstRowNum))
                    {
                        CountRowNull = CopyRow(int.Parse(rowNumberCopy.Text), sheets[nextsheet], sheetBook, countRow);

                        countRow += sheets[nextsheet].LastRowNum - int.Parse(rowNumberCopy.Text) + 2- CountRowNull;
                    }
                    else
                        if (sheetBook.GetRow(sheetBook.LastRowNum) == sheetBook.GetRow(sheetBook.FirstRowNum))
                    {
                        //------ копирование по строкам-----------------
                        CountRowNull = CopyRow(0, sheets[nextsheet], sheetBook);

                        if (int.TryParse(rowNumberCopy.Text, out _) == true)
                            countRow = sheets[nextsheet].LastRowNum - int.Parse(rowNumberCopy.Text) + 2 - CountRowNull;
                        else
                        {
                            MessageBox.Show($"В поле: \r\n {label4.Text} \r\n введены некоректные данные");
                            break;
                        }
                    }
                }
                else
                    continue;
            }
            // -- Формирование имени конечного файла
            fileNameFiished = tabNameBox.SelectedItem.ToString()+ "-" + selectedState + ".xlsx"; 

            pathFile = @"C:\Users\Public\" + fileNameFiished;

            //Проверка нажата ли кнопка сохранить файл
            if (fileNameBox.Text != "")
            {
                pathFile = destinationFolder.Text + "\\" + fileNameBox.Text;

                if (pathFile == "")
                {
                    MessageBox.Show("Укажите путь для сохранения файла!");
                }
                else
                {
                    SaveWorkbook(newbook, pathFile);

                    MessageBox.Show("Сохранение выполнено");
                }
            }
            else
                MessageBox.Show("Введите название файла");
        }
        #endregion

        //=================   Метод получения всех листов книг-источников   =============       
        /// <summary>
        /// Метод получения всех листов выбранных книг Excel
        /// </summary>
        /// <param name="ListBook"> список выбранных книг</param>
        /// <returns></returns>
        #region GetBooksSource(List<string> FileNamesSelect)
        private void GetBooksSource(string[] ListBook)
        {
            IWorkbook[] books = OpenWorkbook(ListBook);
            
            //GetStreamFromBook(ListBook, out books);

            //-------- цикл перебора всех листов из книг ------
            int countSheetBook = 0;

            for (var workbook = 0; workbook < books.Length; workbook++)
            {

                if (books[workbook] == null)
                    break;
                // цикл по листам
                for (int i = 0; i < books[workbook].NumberOfSheets; i++)
                {
                    if (books[workbook].GetSheetAt(i) == null)
                    {
                        break;
                    }
                    else
                    {                     
                            sheets[countSheetBook] = books[workbook].GetSheetAt(i);
                        if (sheets[countSheetBook] == null)
                            break;
                        else
                        {
                            if (!tabNameBox.Items.OfType<string>().Contains(sheets[countSheetBook].SheetName))
                            {
                                tabNameBox.Items.Add(sheets[countSheetBook].SheetName);
                            }
                            countSheetBook++;
                        }
                    }
                }
            }

            //return sheets;
        }

        //=======================   Метод чтения всех книг в поток   ===============================
        /// <summary>
        /// Метод записи в поток книг в цикле
        /// </summary>
        /// <param name="ListBook">массив файлов для записи в поток</param>
        /// <param name="books"></param>
        /// <param name="sheets"></param>
        #region GetStreamFromBook(string[] ListBook, out IWorkbook[] books, out ISheet[] sheets)
        //private void GetStreamFromBook(string[] ListBook, out IWorkbook[] books)
        //{
        //    //---------------   список книг   ----------------
        //    //books = new IWorkbook[ListBook.Length];
        //    books = OpenWorkbook(ListBook);
        //    //----------    список листов книг    ------------
        //    //sheets = new ISheet[500];
        //    //for (int i = 0; i < ListBook.Length; i++)
        //    //{
        //    //    if (ListBook[i] == null)
        //    //        break;
        //    //    else
        //    //        books[i] = OpenWorkbook(ListBook);
        //    //}
        //}
        #endregion

        #endregion     

        //================================================================================
        /// <summary>
        /// Метод копирования диапазона ячеек
        /// </summary>
        /// <param name="range">диапазон ячеек</param>
        /// <param name="sourceSheet">лист-источник</param>
        /// <param name="destinationSheet">лист-приемник</param>
        #region CopyRange(CellRangeAddress range, ISheet sourceSheet, ISheet destinationSheet)
        int CopyRange(CellRangeAddress range, ISheet sourceSheet, ISheet destinationSheet)
           
        {
            MissingCellPolicy cellPolicyCreaate = new MissingCellPolicy();

            cellPolicyCreaate = MissingCellPolicy.RETURN_BLANK_AS_NULL;

            int CountRowNullSkip = 0;

            for (var rowNum = range.FirstRow; rowNum <= range.LastRow; rowNum++)
            {
                IRow sourceRow = sourceSheet.GetRow(rowNum);

                if (sourceRow != null && (sourceRow.GetCell(0)?.CellType != CellType.Blank && sourceRow.GetCell(0, cellPolicyCreaate) != null))
                {
                    if (destinationSheet.GetRow(rowNum - CountRowNullSkip) == null)
                        destinationSheet.CreateRow(rowNum - CountRowNullSkip);
                }
                else
                {
                    CountRowNullSkip++;

                    continue;
                }
                if (sourceRow != null && (sourceRow.GetCell(0)?.CellType != CellType.Blank && sourceRow.GetCell(0, cellPolicyCreaate) != null))
                {
                    IRow destinationRow = destinationSheet.GetRow(rowNum - CountRowNullSkip);

                    for (var col = 0; col < range.LastColumn; col++)
                    {

                        destinationRow.CreateCell(col);

                        CopyCell(sourceRow.GetCell(col), destinationRow.GetCell(col));
                    }
                }
            }
            return CountRowNullSkip;
        }
        #endregion

        //===============   перегруженный метод вставки со смещением на countRowoffset   ======================
        /// <summary>
        /// Метод копирования диапазона ячеек
        /// </summary>
        /// <param name="range">диапазон ячеек</param>
        /// <param name="sourceSheet">лист-источник</param>
        /// <param name="destinationSheet">лист-приемник</param>
        /// <param name="countRowoffset">смещение</param>
        #region CopyRange(CellRangeAddress range, ISheet sourceSheet, ISheet destinationSheet, int countRowoffset)
        int CopyRange(CellRangeAddress range, ISheet sourceSheet, ISheet destinationSheet, int countRowoffset)
        {
            MissingCellPolicy cellPolicyCreaate = new MissingCellPolicy();

            cellPolicyCreaate = MissingCellPolicy.RETURN_BLANK_AS_NULL;

            int countNullRow = 0;

            for (var rowNum = range.FirstRow; rowNum <= range.LastRow; rowNum++)
            {
                IRow sourceRow = sourceSheet.GetRow(rowNum);

                if (sourceRow != null && (sourceRow.GetCell(0)?.CellType != CellType.Blank && sourceRow.GetCell(0, cellPolicyCreaate) != null))
                {
                    if (destinationSheet.GetRow(rowNum + countRowoffset - countNullRow) == null)

                        destinationSheet.CreateRow(rowNum + countRowoffset - countNullRow);
                }
                else
                {
                    countNullRow++;

                    continue;
                }
                if (sourceRow != null && (sourceRow.GetCell(0)?.CellType != CellType.Blank && sourceRow.GetCell(0, cellPolicyCreaate) != null))
                {
                    IRow destinationRow = destinationSheet.GetRow(rowNum + countRowoffset - countNullRow);

                    for (var col = sourceRow.FirstCellNum; col < range.LastColumn; col++)
                    {
                        destinationRow.CreateCell(col);

                        CopyCell(sourceRow.GetCell(col), destinationRow.GetCell(col));
                    }
                }
            }
            return countNullRow;
        } 
        #endregion

        //========================     метод CopyRow    ===========================================
        /// <summary>
        /// Метод установки данных для копирования
        /// </summary>
        /// <param name="row">начальная строка</param>
        /// <param name="sourceSheet">лист-источник</param>
        /// <param name="destinationSheet">лист-приемник</param>
        #region CopyRow(int row, ISheet sourceSheet, ISheet destinationSheet)
        int  CopyRow(int row, ISheet sourceSheet, ISheet destinationSheet)
        {
            if (int.TryParse(countColumn.Text, out _) == true)
            {
                lastColumnSource = int.Parse(countColumn.Text);
            }
            else
                MessageBox.Show($"В поле: \r\n {label5.Text} \r\n введены некоректные данные");
            var range = new CellRangeAddress(0, sourceSheet.LastRowNum, 0, lastColumnSource);

            int coutNullRow;

            return coutNullRow = CopyRange(range, sourceSheet, destinationSheet);
        }
        #endregion

        //===========  перегруженный метод CopyRow со смещение на countRow сторк ===================
        /// <summary>
        /// Метод установки данных для копировани
        /// </summary>
        /// <param name="row">начальная строка</param>
        /// <param name="sourceSheet">лист-источник</param>
        /// <param name="destinationSheet">лист-приемник</param>
        /// <param name="countRow">смещение</param>
        #region CopyRow(int row, ISheet sourceSheet, ISheet destinationSheet, int countRow)
        int CopyRow( int row, ISheet sourceSheet, ISheet destinationSheet, int countRow)
        {
            lastColumnSource = int.Parse(countColumn.Text);
            int rowNumSource = row - 1;
            int countRowoffset = countRow;
            var range = new CellRangeAddress(rowNumSource, sourceSheet.LastRowNum, 0, lastColumnSource);
            int rowNullCount = 0;
            //var range = destinationSheet.CopyRow(row, rowNum);

            return rowNullCount = CopyRange(range, sourceSheet, destinationSheet, countRowoffset);
        }
        #endregion

        //====================  метод CopyCell  ===================================================
        /// <summary>
        /// Метод установки типа ячейки
        /// </summary>
        /// <param name="source">ячейка из книги-источника</param>
        /// <param name="destination">ячейка из книги-приемника</param>
        #region CopyCell(ICell source, ICell destination)
        void CopyCell(ICell source, ICell destination)
        {
                if (destination != null && source != null)
                {
                    // destination.CellComment = source.CellComment;
                    //destination.CellStyle = source.CellStyle;
                    //destination.Hyperlink = source.Hyperlink;

                    switch (source.CellType)
                    {
                        case CellType.Formula:
                            source.SetCellType(CellType.String);
                            destination.SetCellValue(source.StringCellValue); break;
                        case CellType.Numeric:
                            destination.SetCellValue(source.NumericCellValue); break;
                        case CellType.String:
                            destination.SetCellValue(source.StringCellValue); break;
                    }
                }
        }
        #endregion

        //=========================  метод OpenWorkbook   ==========================================
        /// <summary>
        /// Метод считывания данных из файла в поток
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns></returns>
        #region OpenWorkbook(string path)
        IWorkbook[] OpenWorkbook(string[] path)
        {
            IWorkbook[] workbook = new IWorkbook[100];
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == null)
                    break;
                else
                {
                    using (FileStream fileStream = new FileStream(path[i], FileMode.Open, FileAccess.Read))
                    {
                            workbook[i] = WorkbookFactory.Create(fileStream);

                            //GC.Collect(0, GCCollectionMode.Forced);
                    }
                }
            }           
            return workbook;           
        }
        #endregion 

        //=======================  метод Сохранения потока в книгу  =================================
        /// <summary>
        /// Метод записи данных из потока в файл
        /// </summary>
        /// <param name="workbook"> книга для записи</param>
        /// <param name="path">источник данных</param>
        #region SaveWorkbook(IWorkbook workbook, string path)
        void SaveWorkbook(IWorkbook workbook, string path)
        {
            try
            {
                using (var fileStream = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            {               
                    workbook.Write(fileStream);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Обнаружена ошибка в работе программы! \r\n Обратитесь к разработчику \r\n {e}");
            }
        }
        #endregion

        //=====================   Обработчик нажатия кнопки Сформировать  ==========================
        /// <summary>
        /// Обработчик кнопки Сформировать отчет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region RepColl_Click(object sender, EventArgs e)
        private void RepColl_Click(object sender, EventArgs e)
        {
            //--- Сохранение выбранного типа файла из ComboBox 
            string selectedState = TypeFile.SelectedItem.ToString();
            if (sourceFolder.Text == "")
            {
                MessageBox.Show("Выберите каталог-источник");
            }
            else
                if (tabNameBox.Text == "")
            {
                MessageBox.Show("Выберите вкладку");
            }
            else
                if (rowNumberCopy.Text == "")
            {
                MessageBox.Show("Выберите начальную строку для копирования");
            }
            else
                    if (int.TryParse(rowNumberCopy.Text, out _) != true)
            {
                MessageBox.Show($"В поле: \r\n {label4.Text} \r\n введены некоректные данные");
            }
            else
                if (countColumn.Text == "")
            {
                MessageBox.Show("Выберите количество колонок для копирования");
            }
            else
                    if (int.TryParse(countColumn.Text, out _) != true)
            {
                MessageBox.Show($"В поле: \r\n {label5.Text} \r\n введены некоректные данные");
            }
            else
                if (isClickButtonUnloadFile == false && destinationFolder.Text == "")
            {
                MessageBox.Show("Вы не выбрали каталог для сохранения итогового файла!");
            }
            else
                if (isClickButtonSelectAll == false && sourceFolder.Text == "")
                MessageBox.Show("Вы не выбрали каталог с файлами для отчета");
            else
            {
                ImportExcelHSSF_2(filesPath, selectedState);
                //GC.Collect(0, GCCollectionMode.Forced);
            }
            }
        #endregion

        //==============================  Метод выбора файла  =====================================
        /// <summary>
        /// Метод выбора каталога-источника
        /// </summary>
        /// <returns>возвращает список файлов Excel</returns>
        #region GetListFileExcel()
        public string[] GetListFileExcel()
        {
            //Список для имен выбранных файлов

            if (isClickButtonSelectAll == true)
            {
                // очищаем список листов после нового нажатия и формируем его заново
                Array.Clear(fileList, 0, fileList.Length);

                FolderBrowserDialog browser = new FolderBrowserDialog();

                browser.SelectedPath = sourceFolder.Text;

                if (sourceFolder.Text != "")
                    tempPath = sourceFolder.Text;
                else
                    tempPath = "";

                if (browser.ShowDialog() == DialogResult.OK)
                {
                    if (new DirectoryInfo(browser.SelectedPath).GetFiles("*.xlsx").Any(x => x.Extension == ".xlsx"))
                    {
                        if (sourceFolder.Text != "")
                        {
                        sourceFolder.Refresh();
                        sourceFolder.Text = browser.SelectedPath; 
                        tempPath = sourceFolder.Text;
                        }
                        else
                            tempPath = browser.SelectedPath; // prints path
                    }
                    else
                    MessageBox.Show("В указанном каталоге отсутствуют файлы Excel");
                }
                sourceFolder.Text = tempPath;
          
                if (tempPath == "")
                {
                    return null;
                }
                else
                {
                    for (int i = 0; i < Directory.GetFiles(tempPath).Length; i++)
                    {
                        fileList[i] = Directory.GetFiles(tempPath)[i];
                    }
                    return fileList;
                }                
            }
            else
                return null;
        }
        #endregion

        //==================  Обработчик нажатия кнопки выбора  исходных файлов  ========================
        /// <summary>
        /// Обработчик нажатия кнопки Выбор из источника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region SelectAll_Click
        public void SelectAll_Click(object sender, EventArgs e)
        {
            tabNameBox.Items.Clear();

            isClickButtonSelectAll = true;

            filesPath = GetListFileExcel();

            if (filesPath == null)
            {
                MessageBox.Show("Файлы не выбраны");
            }
            else
            {
                GetBooksSource(filesPath);
                //GetNameListWorkBooks(filesPath);
            }
        }
        #endregion
        //==========   Получение названий листов файлов и вывод в comboBox   =========
        /// <summary>
        /// Метод получения имен листов и вывод в комбобокс
        /// </summary>
        #region GetListWorkBooks()
        //private void GetNameListWorkBooks(string[] filesPath)
        //{           
        //    oSheetList = GetBooksSource(filesPath);
         
        //    for (int i = 0; i < oSheetList.Length; i++)
        //    {
        //        //Проверка существования такого листа в comboBox
        //        if (oSheetList[i] == null)
        //            break;
        //        else
        //        if (!tabNameBox.Items.OfType<string>().Contains(oSheetList[i].SheetName))
        //        {
        //            tabNameBox.Items.Add(oSheetList[i].SheetName);
        //        }
        //    }
        //}
        #endregion

        //===============  Обработчик нажатия кнопки сохранения агрегированного файла  ==========================
        /// <summary>
        /// Обработчик нажатия кнопки Выбор для указания места сохранения готового файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region unloadFile_Click
        public void UnloadFile_Click(object sender, EventArgs e)
        {
            isClickButtonUnloadFile = true;
            
            pathFile = destinationFolder.Text;

            GetNameFileIntoButton(pathFile);           
        }
        #endregion

        private void tabNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStateTabName = tabNameBox.SelectedItem.ToString();
        }


        // ========================  Метод сохранения и получения имени файла   ================================
        /// <summary>
        /// Метод вызова диалога для сохранения файла и задание названия 
        /// </summary>
        /// <param name="getPath"></param>
        /// <returns></returns>
        #region GetNameFileIntoButton(string getPath)
        string GetNameFileIntoButton(string getPath)
        {
            FolderBrowserDialog browser2 = new FolderBrowserDialog();

            browser2.SelectedPath = destinationFolder.Text;

            if (browser2.ShowDialog() == DialogResult.OK)
            {
                if (getPath == "")
                {
                    destinationFolder.Text = browser2.SelectedPath;
                    return destinationFolder.Text;
                }
                else
                {
                    browser2.SelectedPath = destinationFolder.Text;
                    return destinationFolder.Text;
                }
            }
            else
            {
               if(destinationFolder.Text == "")
                MessageBox.Show("Укажите путь для сохранения файла!");
                return null;
            }  
        }
        #endregion

        //==================   Обработчик нажатия кнопки Запустить   ========================   
        /// <summary>
        /// Обработчик нажатия кнопки Запустить установку конфига
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         #region
        private void ButStartFormConfig_Click(object sender, EventArgs e)
        {
            //Запуск второй формы с настройками конфига
            ConfigSettings cs = new ConfigSettings
            {
                Owner = this
            };

            cs.ShowDialog();

      
        }
        #endregion

        //============   Обработчик события на нажатие в текстовое поле "Имя Файла"
        /// <summary>
        /// Обработчик события на нажатие в текстовое поле "Имя Файла"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         #region fileNameBox_MouseClick(object sender, MouseEventArgs e)
        private void fileNameBox_MouseClick(object sender, MouseEventArgs e)
        {
            // -- Формирование имени конечного файла
           
            string selectedState = TypeFile.SelectedItem.ToString();

            if (tabNameBox.SelectedItem == null)
                MessageBox.Show("Ввод имени файла осуществляйте в последнюю очередь!!!");
            else
            {
                fileNameFiished = tabNameBox.SelectedItem.ToString() + "-" + selectedState + ".xlsx";

                fileNameBox.Text = fileNameFiished;
            }
        }
        #endregion
    }
}
