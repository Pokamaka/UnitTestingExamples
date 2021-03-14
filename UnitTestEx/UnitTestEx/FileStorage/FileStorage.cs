using System;
using System.Collections.Generic;
using System.Text;
using UnitTestEx;

namespace UnitTestEx
{
    /// <summary>
    /// Класс файлового хранилища
    /// </summary>
    public class FileStorage
    {
        /// <summary>
        /// Само "хранилище" с файлами
        /// </summary>
        private List<File> files = new List<File>();

        /// <summary>
        /// Доступный размер хранилища
        /// </summary>
        private double availableSize = 100;

        /// <summary>
        /// Максимальный размер хранилища
        /// </summary>
        private double maxSize = 100;

        /// <summary>
        /// Главная функция приложения
        /// </summary>
        /// <param name="size">Принимает максимальный размер хранилища</param>
        public FileStorage(int size)
        {
            maxSize = size;
            availableSize += maxSize;
        }

        /// <summary>
        /// Если надо будет установить дэфолтный размер и допустимый
        /// Construct object and set max storage size and available size based on default value=10
        /// </summary>
        public FileStorage()
        {

        }

        /// <summary>
        /// Добавляпем файл в хранилище, если имя уникально и размер не привышает допустимый
        /// </summary>
        /// <param name="file">Принимает файл для сохранения в хранилище</param>
        /// <returns>Возращает True - сохранен, False - не сохранен</returns>
        public bool Write(File file)
        {
            // Проверка существования файла
            if (IsExists(file.GetFilename()))
            {
                //Если файл уже есть, то кидаем ошибку
                throw new FileNameAlreadyExistsException();
            }

            //Проверка того, размер файла не привышает доступный объем памяти
            if (file.GetSize() >= availableSize)
            {
                return false;
            }

            // Добалвяем файл в лист
            files.Add(file);
            // Добалвяем файл в лист
            availableSize -= file.GetSize();

            return true;
        }

        /// <summary>
        /// Функция проверки уникальности файла в храниилще
        /// </summary>
        /// <param name="fileName">Принимает имя добавляемоего в хранилище файла</param>
        /// <returns>Возращает True - файл уже есть, False - файл уникален<returns>
        public bool IsExists(String fileName)
        {
            // Для каждого элемента с типом File из Листа files
            foreach (File file in files)
            {
                // Проверка имени
                if (file.GetFilename().Contains(fileName))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Функция удаления файла их хранилища
        /// </summary>
        /// <param name="fileName">Умя удаляемого файла</param>
        /// <returns>Возращает True - файл удален, False - файл не удалёене</returns>
        public bool Delete(String fileName)
        {
            return files.Remove(GetFile(fileName));
        }

        /// <summary>
        /// Функция выдачи всех  файлов хранилиища
        /// </summary>
        /// <returns>Возращает список хранимых файлов</returns>
        public List<File> GetFiles()
        {
            return files;
        }

        /// <summary>
        /// Функция получения файла из хранилища
        /// </summary>
        /// <param name="fileName">Принимает имя необходимого файла</param>
        /// <returns>Возращает искомый файл из хранилища</returns>
        public File GetFile(String fileName)
        {
            if (IsExists(fileName))
            {
                foreach (File file in files)
                {
                    if (file.GetFilename().Contains(fileName))
                    {
                        return file;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Удаление всех файлов из хранилища
        /// </summary>
        /// <returns>Возращает True - все файлы удалены, False - ничего не изменилось</returns>
        public bool DeleteAllFiles()
        {
            files.RemoveRange(0, files.Count - 1);
            return files.Count == 0;
        }

    }
}
