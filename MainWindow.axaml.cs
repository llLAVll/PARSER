using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Dicom;
using System;
using System.IO;

namespace PARSER
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OpenFilesClick(object sender, RoutedEventArgs args)
        {
            // Get top level from the current control. Alternatively, you can use Window reference instead.
            var topLevel = TopLevel.GetTopLevel(this);

            // Start async operation to open the dialog.
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open Text File",
                AllowMultiple = false
            });

            if (files.Count >= 1)
            {
                // Open reading stream from the first file.
                await using var stream = await files[0].OpenReadAsync();
                using var streamReader = new StreamReader(stream);
                // Reads all the content of file as a text.
                var fileContent = await streamReader.ReadToEndAsync();
            }
        }
        //private void OpenFilesClick(object sender, RoutedEventArgs e)
        //{
       
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Title = "Open Dicom files";
        //    //openFileDialog.Filters.Add();

        //    //if (openFileDialog. == true)
        //    //{
        //    //    foreach (string filename in openFileDialog.FileNames)
        //    //    {
        //    //        listBoxFiles.Items.Add(filename);
        //    //        // Здесь можно добавить код для обработки DICOM файла с помощью библиотеки fo-dicom
        //    //        // Например:
        //    //        // DicomFile dicomFile = DicomFile.Open(filename);
        //    //        // DicomDataset dataset = dicomFile.Dataset;
        //    //        // Здесь вы можете работать с содержимым DICOM файла
        //    //    }
        //    //}

        //}
      
        /*
                private void LoadFiles_Click(object sender, RoutedEventArgs e)
                {

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Title = "Open Dicom files";
                    //openFileDialog.Filters.Add();

                    //if (openFileDialog. == true)
                    //{
                    //    foreach (string filename in openFileDialog.FileNames)
                    //    {
                    //        listBoxFiles.Items.Add(filename);
                    //        // Здесь можно добавить код для обработки DICOM файла с помощью библиотеки fo-dicom
                    //        // Например:
                    //        // DicomFile dicomFile = DicomFile.Open(filename);
                    //        // DicomDataset dataset = dicomFile.Dataset;
                    //        // Здесь вы можете работать с содержимым DICOM файла
                    //    }
                    //}

                }
                private async void OpenFile_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filters.Add(new FileDialogFilter() { Name = "DICOM Files", Extensions = { "dcm" } });

                    string[] result = await dialog.ShowAsync(this);
                    if (result.Length > 0)
                    {
                        LoadDicomFile(result[0]);
                    }
                }
                private void ViewImage_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
                {
                    // View DICOM image here
                }
                private void LoadDicomFile(string filePath)
                {
                    try
                    {
                        DicomFile dicomFile = DicomFile.Open(filePath);
                        //DicomImage dicomImage = new DicomImage(dicomFile.Dataset);
                        //this.dicomImage.Source = dicomImage.RenderImage().As<Avalonia.Media.Imaging.IBitmap>();
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Console.WriteLine($"Error loading DICOM file: {ex.Message}");
                    }
                }
            }

            public class MyView : UserControl
            {
                private async void OpenFileButton_Clicked(object sender, RoutedEventArgs args)
                {
                    // Get top level from the current control. Alternatively, you can use Window reference instead.
                    var topLevel = TopLevel.GetTopLevel(this);

                    // Start async operation to open the dialog.
                    var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
                    {
                        Title = "Open File",
                        AllowMultiple = false,
                       // FileTypeFilter = ,
                     });

                    if (files.Count >= 1)
                    {
                        // Open reading stream from the first file.
                        await using var stream = await files[0].OpenReadAsync();
                        using var streamReader = new StreamReader(stream);
                        // Reads all the content of file as a text.
                        var fileContent = await streamReader.ReadToEndAsync();
                    }
                }
            }    

            */
    }
}