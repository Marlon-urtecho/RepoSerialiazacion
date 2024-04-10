using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public interface IFileRepository
    {
        void OpenOrCreateFile();
        void OpenFile();
        void WriteRecordToFile(Record record);
        string? ReadNextRecord();
        void ResetFilePointer();
        void CloseFile();
    }
}
