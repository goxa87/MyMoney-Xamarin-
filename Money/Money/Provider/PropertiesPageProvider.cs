using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Xamarin.Forms;

namespace Money
{
    public class PropertiesPageProvider : IPropertyiesProvider
    {
        /// <summary>
        /// окно свойств
        /// </summary>
        public IPropertiesView view { get; set; }
        
        /// <summary>
        /// Сервис формирования файла
        /// </summary>
        IGetFileService serviceFile;

        /// <summary>
        /// Сервис формирования файла
        /// </summary>
        public IGetFileService ServiceFile
        {
            get
            {
                return serviceFile;
            }
            set
            {
                this.serviceFile = value;
            }
        }

        
        public PropertiesPageProvider(IGetFileService service, IPropertiesView concreteView)
        {
            ServiceFile = service;
            view = concreteView;
        }

        /// <summary>
        /// обработчик вызова окна категорий доходов
        /// </summary>
        public void CallDohodPage()
        {

        }
        /// <summary>
        /// обработчик вызова окна категорий расходов
        /// </summary>
        public void CallRashPage()
        {

        }
        /// <summary>
        /// отчистка истории
        /// </summary>
        public void Clearhistory()
        {

        }
        /// <summary>
        /// Формирование файла
        /// </summary>
        async public void SaveFileOperation(object sender, EventArgs e)
        {
            Debug.WriteLine("Comme сэйв метод в презентере secsessfuly");
            //var x = new Page();
            //string title = await x.DisplayPromptAsync("Название", "Введите заголовок сохранения(желательно с именем пользователя)", "ОК", "Отмена");
            //if (string.IsNullOrWhiteSpace(title))
            //    await x.DisplayAlert("Ошибка", "Пустая строка заголовка", "OK");
            //else
            //{
                serviceFile.MakeFile(new FileServiceArgs("тест",new DateTime(2018,01,01),DateTime.Today.AddDays(1)));
            //}
        }
    }
}
