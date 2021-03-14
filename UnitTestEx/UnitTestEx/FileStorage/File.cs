using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestEx
{
    /// <summary>
    /// Класс с полями описания файла
    /// </summary>
    public class File
    {
        /// <summary>
        /// Расширение
        /// </summary>
        private string extension;

        /// <summary>
        /// Имя файла
        /// </summary>
        private string filename;

        /// <summary>
        /// Содержимое
        /// </summary>
        private string content;

        /// <summary>
        /// Размер файла
        /// </summary>
        private double size;

        /// <summary>
       /// Основная функция описания файла
       /// </summary>
       /// <param name="filename">Принимает имя файла</param>
       /// <param name="content">Принимает содержимое файла</param>
        public File(String filename, String content)
        {
            this.filename = filename;
            this.content = content;
            this.size = content.Length / 2;
            this.extension = filename.Split('.')[filename.Split('.').Length - 1];
        }

        /// <summary>
        /// Функция запроса размера файла
        /// </summary>
        /// <returns>Возращает - размер файла (int )</returns>
        public double GetSize()
        {
            return (int)size;
        }

        /// <summary>
        /// Функция запроса имени файла
        /// </summary>
        /// <returns>Возращает - имя файла (string)</returns>
        public string GetFilename()
        {
            return filename;
        }
    }
}
