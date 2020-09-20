using no.difi.vefa.peppol.common.api;
using System;

/*
 * Copyright 2015-2017 Direktoratet for forvaltning og IKT
 *
 * This source code is subject to dual licensing:
 *
 *
 * Licensed under the EUPL, Version 1.1 or – as soon they
 * will be approved by the European Commission - subsequent
 * versions of the EUPL (the "Licence");
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 *
 * See the Licence for the specific language governing
 * permissions and limitations under the Licence.
 */

namespace no.difi.vefa.peppol.common.util
{
	using PerformAction = no.difi.vefa.peppol.common.api.PerformAction;
	//using PerformResult = no.difi.vefa.peppol.common.api.PerformResult;
	using PeppolRuntimeException = no.difi.vefa.peppol.common.lang.PeppolRuntimeException;

	public class ExceptionUtil
	{

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static <E extends Exception> void perform(Class<E> cls, no.difi.vefa.peppol.common.api.PerformAction action) throws E
		public static void perform<E>(System.Type cls, PerformAction action) where E : Exception
		{
				cls = typeof(E);
			try
			{
				action();
			}
			catch (Exception e)
			{
				throw new /*prepare*/Exception( e.Message);
			}
		}

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static <T, E extends Exception> T perform(Class<E> cls, no.difi.vefa.peppol.common.api.PerformResult<T> action) throws E
		public static T perform<T, E>(System.Type cls, PerformResult<T> action) where E : Exception
		{
				cls = typeof(E);
			try
			{
				return action();
			}
			catch (Exception e)
			{
				throw prepareException(cls, e.Message, e);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static <T, E extends Exception> T perform(Class<E> cls, String message, no.difi.vefa.peppol.common.api.PerformResult<T> action) throws E
		public static T perform<T, E>(System.Type cls, string message, PerformResult<T> action) where E : Exception
		{
				cls = typeof(E);
			try
			{
				return action();
			}
			catch (Exception e)
			{
				throw prepareException(cls, message, e);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static <E extends Exception> E prepareException(Class<E> cls, String message, Throwable throwable) throws E
		private static E prepareException<E>(System.Type cls, string message, Exception throwable) where E : Exception
		{
				cls = typeof(E);
			try
			{
				return cls.GetConstructor(typeof(string), typeof(Exception)).newInstance(message, throwable);
			}
			catch (Exception e)
			{
				throw new PeppolRuntimeException(string.Format("Unable to initiate exception '{0}'.", cls), e);
			}
		}
	}
}