using System;
using System.IO;

namespace EssentialWCF
{
    public class SimpleService : ISimpleContract
    {
        private DateTime _instanceTime;

        public SimpleService()
        {
            _instanceTime = DateTime.Now;
        }

        public DateTime GetCurrentTime()
        {
            return _instanceTime;
        }

        public string[] GetFolderContent(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    return Directory.GetFiles(path); 
                }
                else
                {
                    return new string[] { "ошибка: папка не найдена" };
                }
            }
            catch (Exception ex)
            {
                return new string[] { "Ошибка: " + ex.Message };
            }
        }
    }
}
