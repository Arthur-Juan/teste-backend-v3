﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Data.Errors.Exceptions.Genre;

public class InvalidGenreException : Exception
{
	public InvalidGenreException(string message) : base(message)
	{

	}
}
