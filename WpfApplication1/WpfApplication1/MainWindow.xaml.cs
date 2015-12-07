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

        private string currentA;
        private string currentB;
        public MainWindow()
        {
            InitializeComponent();
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
                string filePath = Path.Combine(textBoxFileName.Text);
                string query = "Действительно удалить файл \n" + filePath + " ?";
                if (MessageBox.Show(query, "Удалить файл?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    File.Delete(filePath);
                    
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
                string filePath = Path.Combine(textBoxFileName.Text);
                string query = "Действительно переместить файл \n" + filePath + " ?";
                if (MessageBox.Show(query, "Переместить файл?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    File.Move(filePath, textBoxNewPath.Text);
                   
                }
            }
            finally
            {
                MessageBox.Show("Ви точно хочете перемістити файл: ");
            }
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = Path.Combine(textBoxFileName.Text);
                File.Copy(filePath, textBoxNewPath.Text);
              
            }
            finally
            {
                MessageBox.Show("Ви точно хочете скопіювати файл: ");
            }
        }
       
        private void buttonDisplay_Click(object sender, RoutedEventArgs e)
        {
         DirectoryInfo dir = new DirectoryInfo(textBoxInput.Text);
            listBoxA.Items.Add(dir);
            currentA = dir.FullName;
            if (dir.Exists)
            {
                
                DisplayFolderList(dir.FullName);
                return;
            }
            string folderPath = textBoxInput.Text;
            FileInfo fi = new FileInfo(folderPath);
            if (fi.Exists)
            {
                DisplayFolderList(fi.Directory.FullName);
                int i = listBoxA.Items.IndexOf(fi.Name);
                listBoxA.SelectedIndex = i;
                return;
            }

        }
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

        private void buttonDisplay_Copy_Click(object sender, RoutedEventArgs e)
        {
            {
                DirectoryInfo dir = new DirectoryInfo(textBoxInput.Text);
                listBoxA.Items.Add(dir);
                currentA = dir.FullName;
                if (dir.Exists)
                {

                    DisplayFolderList(dir.FullName);
                    return;
                }
                string folderPath = textBoxInput.Text;
                FileInfo fi = new FileInfo(folderPath);
                if (fi.Exists)
                {
                    DisplayFolderList(fi.Directory.FullName);
                    int i = listBoxB.Items.IndexOf(fi.Name);
                    listBoxB.SelectedIndex = i;
                    return;
                }
            }
        }
        private void listBoxA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectionString = listBoxA.SelectedItem.ToString();
                               string fullFileName = Path.Combine(currentA, selectionString);
                DisplayFileInfo(fullFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectionString = listBoxB.SelectedItem.ToString();
                string fullPathName = Path.Combine(currentB, selectionString);
                DisplayFolderList(fullPathName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayFolderList(string folder)
        {
            DirectoryInfo di = new DirectoryInfo(folder);
            ClearAllFields();
            currentA = di.FullName;
            currentB = di.FullName;

            foreach (DirectoryInfo d in di.GetDirectories())
                listBoxA.Items.Add(d.Name);

            foreach (FileInfo f in di.GetFiles())
                listBoxA.Items.Add(f.Name);
        }
        protected void ClearAllFields()
        {
            listBoxB.Items.Clear();
            listBoxA.Items.Clear();
            textBoxFileName.Text = "";
            textBoxCreationTime.Text = "";
            textBoxLastAccessTime.Text = "";
            textBoxLastWriteTime.Text = "";
            textBoxFileSize.Text = "";
        }
    }
}