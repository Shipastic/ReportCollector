using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RepCol_2
{
    public partial class ConfigSettings : Form
    {
		public ConfigSettings()
        {
            InitializeComponent();
		}

        //Создание экземпляра класса OpenFileDialog
        OpenFileDialog openFileDialog = new OpenFileDialog();

        //Переменная для хранения пути до конфиг.файла
        string tempPath = "";

        //Переменная для хранения пути к каталогу-источнику
        string sourceFolderPath = "";

        //Переменная для хранения пути к каталогу-приемнику
        string destinationFolderPath = "";

        // Флаг нажатия кнопки Выбора каталога-источника
        bool isClickbutSelectSourcePath = false;

        // Флаг нажатия кнопки Выбора каталога-источника
        bool isClickbutSelectDestinPath = false;

        //=================   Обработчик события закрытия формы   =================
        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region configSettings_FormClosed(object sender, FormClosedEventArgs e)
        private void ConfigSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form RepCol = Application.OpenForms[0];
            RepCol.Show();
        }
        #endregion

        //=========   Обработчик нажатия кнопки выбора конфиг. файла   ============
        /// <summary>
        /// Обработчик нажатия кнопки выбора конфиг. файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region butSetFolder_Click(object sender, EventArgs e)
        private void ButSetFolder_Click(object sender, EventArgs e)
        {
            using (openFileDialog)
            {
                openFileDialog.Multiselect = true;
                openFileDialog.InitialDirectory = @"C:";
                openFileDialog.Filter = "config files (*.config)|*.config";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
               
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tempPath = openFileDialog.FileName;
                    textPathSet.Text = tempPath;
                }
            }
        }

        #endregion

        //========  Обработчик нажатия кнопки Выбора каталога-источника   =========
        /// <summary>
        /// Обработчик кнопки Выбора каталога-источника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region butSelectSourcePath_Click(object sender, EventArgs e)
        private void ButSelectSourcePath_Click(object sender, EventArgs e)
        {
                FolderBrowserDialog browser = new FolderBrowserDialog();

                if (browser.ShowDialog() == DialogResult.OK)
            {
                if (new DirectoryInfo(browser.SelectedPath).GetFiles("*.xlsx").Any(x => x.Extension == ".xlsx"))
                {
                    sourceFolderPath = browser.SelectedPath;
                }
                else
                {
                    MessageBox.Show("В указанном каталоге отсутствуют файлы Excel");
                }
                     
            }
            textSourcePath.Text = sourceFolderPath;

            isClickbutSelectSourcePath = true;
        }
        #endregion

        //========  Обработчик нажатия кнопки Выбора каталога-приемника   =========
        /// <summary>
        /// Обработчик кнопки Выбора каталога-приемника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region butSelectDestinPath_Click(object sender, EventArgs e)
        private void ButSelectDestinPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();

            if (browser.ShowDialog() == DialogResult.OK)
            {
                destinationFolderPath = browser.SelectedPath;
            }
            textDestinationPath.Text = destinationFolderPath;

            isClickbutSelectDestinPath = true;
        }
        #endregion

        //==========   Обработчик нажатия кнопки Сохранить   =============
        /// <summary>
        /// Обработчик нажатия кнопки Сохранить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region butSaveSettings_Click(object sender, EventArgs e)
        private void ButSaveSettings_Click(object sender, EventArgs e)
        {
            ReportCollector main = this.Owner as ReportCollector;

            tempPath = textPathSet.Text;
            if (tempPath == "")
                MessageBox.Show("Выберите конфиг файл!!!");          
            try
            {
                //if (ReadSettings() == false)
                //    MessageBox.Show("В файле конфигурации нет информации...");
                //else
                SaveSettings();
                    MessageBox.Show("Информация успешно загружена из файла конфигурации...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникала проблема при сохранении данных из файла конфигурации:");
                MessageBox.Show(ex.Message);
            }

            // Сохранение текущего состояния.
            void SaveSettings()
            {
                // Сохранение происходит при помощи работы с XML.
                XmlDocument doc = loadConfigDocument();

                // Открываем узел appSettings, в котором содержится перечень настроек.
                XmlNode node = doc.SelectSingleNode("//appSettings");

                // Массив ключей (создан для упрощения обращения к файлу конфигурации).
                string[] keys = new string[]
                    {
                "sourcePath",
                "destinationPath",
                "configFilePath"
                    };

                // Массив значений (создан для упрощения обращения к файлу конфигурации).
                string[] values = new string[]
                {
                textSourcePath.Text,
                textDestinationPath.Text,
                textPathSet.Text
                };

                // Цикл модификации файла конфигурации.
                for (int i = 0; i < keys.Length; i++)
                {
                    // Обращаемся к конкретной строке по ключу.
                    XmlElement element = node.SelectSingleNode(string.Format("//add[@key='{0}']", keys[i])) as XmlElement;

                    // Если строка с таким ключем существует - записываем значение.
                    if (element != null) { element.SetAttribute("value", values[i]); }
                    else
                    {
                        // Иначе: создаем строку и формируем в ней пару [ключ]-[значение].
                        element = doc.CreateElement("add");
                        element.SetAttribute("key", keys[i]);
                        element.SetAttribute("value", values[i]);
                        node.AppendChild(element);
                    }
                }

                // Сохраняем результат модификации.
                doc.Save(textPathSet.Text);
                if (main != null)
                {
                    main.sourceFolder.Text = textSourcePath.Text;
                    main.destinationFolder.Text = textDestinationPath.Text;
                    main.textSettingPath.Text = textPathSet.Text;
                }
                MessageBox.Show("Сохранение настроек выполнено");
            }

            // Восстановление данных из файла конфигурации.
            bool ReadSettings()
            {
                // Загрузка настроек по парам [ключ]-[значение].
                NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
                if (allAppSettings.Count < 1) { return (false); }

                // Восстановление состояния:
                string sourceFolder = allAppSettings["sourcePath"];
                string destinationFolder = allAppSettings["destinationPath"];
                string configFilePath = allAppSettings["configFilePath"];

                textSourcePath.Text = sourceFolder;
                textDestinationPath.Text = destinationFolder;
                textPathSet.Text = configFilePath;
                return (true);
            }
        }
        #endregion

        //===================   Создание конфиг.файла   ==================
        /// <summary>
        /// Создает новый конфигурационный документ.
        /// </summary>
        /// <returns></returns>
        #region XmlDocument loadConfigDocument()
        private XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(tempPath);
                return doc;
            }
            catch (FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }
        #endregion


        //===============    Обработчик кнопки Загрузить   ================
        /// <summary>
        /// Обработчик кнопки Загрузить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region button1_Click(object sender, EventArgs e)
        private void ButLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReadSettings() == false)
                    MessageBox.Show("В файле конфигурации нет информации...");
                else
                    MessageBox.Show("Информация успешно загружена из файла конфигурации...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникала проблема при сохранении данных из файла конфигурации:");
                MessageBox.Show(ex.Message);
            }
            // Восстановление данных из файла конфигурации.
            bool ReadSettings()
            {
                // Загрузка настроек по парам [ключ]-[значение].
                NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
                if (allAppSettings.Count < 1) { return (false); }

                // Восстановление состояния:
                string sourceFolder = allAppSettings["sourcePath"];
                string destinationFolder = allAppSettings["destinationPath"];
                string configFilePath = allAppSettings["configFilePath"];

                textSourcePath.Text = sourceFolder;
                textDestinationPath.Text = destinationFolder;
                textPathSet.Text = configFilePath;
                return (true);
            }
        }
        #endregion
    }
}
