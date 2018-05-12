using System.IO;
using Prism.Interactivity.InteractionRequest;

namespace FileEncryptor
{
    public class OperationsViewModel
    {
        private readonly string _key;

        public InteractionRequest<INotification> ShowErrorNotificationRequest { get; private set; }

        public InteractionRequest<FileSaveAsNotification> FileSaveAsInteractionRequest { get; private set; }
        public OperationsViewModel(string key)
        {
            _key = key;
            ShowErrorNotificationRequest = new InteractionRequest<INotification>();
            FileSaveAsInteractionRequest = new InteractionRequest<FileSaveAsNotification>();
        }

        public void Process(string inputFile)
        {
            var fileInfo = new FileInfo(inputFile);
            long length = fileInfo.Length;
            if (length > 1024 * 1024 * 1024) ShowErrorMessage();
            else if (fileInfo.Extension == ".encrpt") DecryptFile(inputFile);
            else EncryptFile(inputFile);
        }

        private void EncryptFile(string inputFile)
        {
            var fileInfo = new FileInfo(inputFile);
            
            SaveFile("Save Encrypted",
                fileInfo.Name + ".encrpt",
                ".encrpt",
                "Encrypted File (.encrpt)|*.encrpt");
        }

        private void SaveFile(string saveFileTitle, string defaultFileName, string outputFileExtention, string filter)
        {
            var file = new FileSaveAsNotification()
            {
                Title = saveFileTitle,
                DefaultFileName = defaultFileName,
                OutputFileExtention = outputFileExtention,
                OutputFileExtentionFilter = filter,
            };
            FileSaveAsInteractionRequest.Raise(file);
            if (file.FileSaved)
            {
                
            }
        }

        private void DecryptFile(string inputFile)
        {
            var fileInfo = new FileInfo(inputFile);
            var extention = fileInfo.Extension;
            var outputFileName = inputFile.Replace(extention, "");
            var outputFileInfo = new FileInfo(outputFileName);
            var outputExtention = outputFileInfo.Extension;

            SaveFile("Save Decrypted",
                outputFileInfo.Name,
                ".xlsx",
                $"Decrypted File ({outputExtention})|*{outputExtention}");
        }

        private void ShowErrorMessage()
        {
            ShowErrorNotificationRequest.Raise(
                new Notification { Content = "The file is too big", Title = "Error" });
        }
    }
}