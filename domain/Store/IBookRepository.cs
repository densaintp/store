﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
	interface IBookRepository //Зачем нужны?
	{
		Book[] GetAllByTitle(string titlePart); // Метод возвращающий названия книг

	}
}
