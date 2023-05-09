using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infra.CloudServices.Interfaces
{
    internal interface IFileStorageService
    {
        void UploadFile(byte[] bytes, string fileName);
    }
}
