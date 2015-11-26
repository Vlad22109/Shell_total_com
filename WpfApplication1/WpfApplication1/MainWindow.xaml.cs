using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Путь к папке
        private string currentFolderPath;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод, для очистки содержимого всех элементов управления
        protected void ClearAllFields()
        {
            listBoxFolders.Items.Clear();
            listBoxFiles.Items.Clear();
            textBoxFolder.Text = "";
            textBoxFileName.Text = "";
            textBoxCreationTime.Text = "";
            textBoxLastAccessTime.Text = "";
            textBoxLastWriteTime.Text = "";
            textBoxFileSize.Text = "";
        }

        // Метод, для отображения информации о файле
        protected void DisplayFileInfo(string fileFullName)
        {
            FileInfo fi = new FileInfo(fileFullName);
            if (!fi.Exists)
            {
                throw new FileNotFoundException("Файл " + fileFullName + " не найден :(");
            }
            textBoxFileName.Text = fi.Name;
            textBoxFileSize.Text = (fi.Length / 1024).ToString() + " kb";
            textBoxCreationTime.Text = fi.CreationTime.ToLongTimeString();
            textBoxLastAccessTime.Text = fi.LastAccessTime.ToLongTimeString();
            textBoxLastWriteTime.Text = fi.LastWriteTime.ToLongTimeString();
        }

        // Метод, для отображения содержимого папок в ListBox
        protected void DisplayFolderList(string folder)
        {
            DirectoryInfo di = new DirectoryInfo(folder);

            if (!di.Exists)
                throw new DirectoryNotFoundException("Папка не найдена :(");
            ClearAllFields();
            textBoxFolder.Text = di.FullName;
            currentFolderPath = di.FullName;

            // Отображение списков всех подпапок и файлов
            foreach (DirectoryInfo d in di.GetDirectories())
                listBoxFolders.Items.Add(d.Name);

            foreach (FileInfo f in di.GetFiles())
                listBoxFiles.Items.Add(f.Name);
        }

        private void buttonDisplay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string folderPath = textBoxInput.Text;
                DirectoryInfo di = new DirectoryInfo(folderPath);
                if (di.Exists)
                {
                    DisplayFolderList(di.FullName);
                    return;
                }

                FileInfo fi = new FileInfo(folderPath);
                if (fi.Exists)
                {
                    DisplayFolderList(fi.Directory.FullName);
                    int i = listBoxFiles.Items.IndexOf(fi.Name);
                    listBoxFiles.SelectedIndex = i;
                    return;
                }

                throw new FileNotFoundException("Файл или папка с таким именем не существует");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectionString = listBoxFiles.SelectedItem.ToString();
                string fullFileName = Path.Combine(currentFolderPath, selectionString);
                DisplayFileInfo(fullFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectionString = listBoxFolders.SelectedItem.ToString();
                string fullPathName = Path.Combine(currentFolderPath, selectionString);
                DisplayFolderList(fullPathName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string folderPath = new FileInfo(currentFolderPath).DirectoryName;
                DisplayFolderList(folderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
               if (openFileDialog1.ShowDialog() == DialogResult)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = Path.Combine(currentFolderPath, textBoxFileName.Text);
                string query = "Действительно удалить файл \n" + filePath + " ?";
                if (MessageBox.Show(query, "Удалить файл?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    File.Delete(filePath);
                    DisplayFolderList(currentFolderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удается удалить файл из-за исключения: " + ex.Message);
            }
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = Path.Combine(currentFolderPath, textBoxFileName.Text);
                string query = "Действительно переместить файл \n" + filePath + " ?";
                if (MessageBox.Show(query, "Переместить файл?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    File.Move(filePath, textBoxNewPath.Text);
                    DisplayFolderList(currentFolderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ви точно хочете перемвстити файл: " + ex.Message);
            }
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = Path.Combine(currentFolderPath, textBoxFileName.Text);
                File.Copy(filePath, textBoxNewPath.Text);
                DisplayFolderList(currentFolderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ви точно хочете скопіювати файл: " + ex.Message);
            }
        }
    }
}