using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class FileRepository : IFileRepository
    {
        private StreamWriter? _fileWriter;
        private StreamReader? _fileReader;
        private FileStream? _fileStream;
        private string _fileName;

        public FileRepository(string fileName)
        {
            _fileName = fileName;
        }

        public void OpenOrCreateFile()
        {
            try
            {
                _fileStream = new FileStream(_fileName, FileMode.OpenOrCreate,
                        FileAccess.Write);
                _fileWriter = new StreamWriter(_fileStream);
            }
            catch (IOException)
            {
                throw new IOException("Error al abrir el archivo");
            }
        }

        public void OpenFile()
        {
            try
            {

                _fileStream = new FileStream(_fileName, FileMode.Open,
                    FileAccess.Read);
                _fileReader = new StreamReader(_fileStream);

            }catch (IOException) 
            {
                throw new IOException("Error al abrir el archivo");
            }
        }

        public void WriteRecordToFile(Record record)
        {
            try
            {
                _fileWriter?.WriteLine($"{record.Account}, {record.FirstName}," +
                    $"{record.LastName}, {record.Balance}");
            }catch(IOException)
            {
                throw new IOException("Error al escribir en archivo.");
            }
        }

        public string? ReadNextRecord()
        {
            try
            {

                return _fileReader?.ReadLine();

            }catch(IOException)
            {
                throw new IOException("Error al leer del archivo.");
            }
        }

        public void ResetFilePointer()
        {
            try
            {

            }catch(IOException)
            {
                throw new IOException("Error al reestablecer el puntero del archivo");
            }
        }

        public void CloseFile()
        {
            try
            {
                _fileWriter?.Close();
                _fileReader?.Close();
            }catch(IOException)
            {
                throw new IOException("No se puede cerrar el archivo.");
            }
        }

    }
}
