namespace Example
{
	using System;
	using System.Runtime.CompilerServices;
	using UnityEngine;

	public static partial class FuncExtensions
	{
		// PUBLIC METHODS

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult SafeInvoke<TResult>                                (this Func<TResult>                                 func)                                                                                  { TResult result = default; if (func != null) { try { result = func();                                               } catch (Exception exception) { Debug.LogException(exception); } } return result; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult SafeInvoke<T1, TResult>                            (this Func<T1, TResult>                             func, T1 arg1)                                                                         { TResult result = default; if (func != null) { try { result = func(arg1);                                           } catch (Exception exception) { Debug.LogException(exception); } } return result; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult SafeInvoke<T1, T2, TResult>                        (this Func<T1, T2, TResult>                         func, T1 arg1, T2 arg2)                                                                { TResult result = default; if (func != null) { try { result = func(arg1, arg2);                                     } catch (Exception exception) { Debug.LogException(exception); } } return result; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult SafeInvoke<T1, T2, T3, TResult>                    (this Func<T1, T2, T3, TResult>                     func, T1 arg1, T2 arg2, T3 arg3)                                                       { TResult result = default; if (func != null) { try { result = func(arg1, arg2, arg3);                               } catch (Exception exception) { Debug.LogException(exception); } } return result; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult SafeInvoke<T1, T2, T3, T4, TResult>                (this Func<T1, T2, T3, T4, TResult>                 func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)                                              { TResult result = default; if (func != null) { try { result = func(arg1, arg2, arg3, arg4);                         } catch (Exception exception) { Debug.LogException(exception); } } return result; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult SafeInvoke<T1, T2, T3, T4, T5, TResult>            (this Func<T1, T2, T3, T4, T5, TResult>             func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)                                     { TResult result = default; if (func != null) { try { result = func(arg1, arg2, arg3, arg4, arg5);                   } catch (Exception exception) { Debug.LogException(exception); } } return result; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, TResult>        (this Func<T1, T2, T3, T4, T5, T6, TResult>         func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)                            { TResult result = default; if (func != null) { try { result = func(arg1, arg2, arg3, arg4, arg5, arg6);             } catch (Exception exception) { Debug.LogException(exception); } } return result; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, TResult>    (this Func<T1, T2, T3, T4, T5, T6, T7, TResult>     func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)                   { TResult result = default; if (func != null) { try { result = func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);       } catch (Exception exception) { Debug.LogException(exception); } } return result; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)          { TResult result = default; if (func != null) { try { result = func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8); } catch (Exception exception) { Debug.LogException(exception); } } return result; }
	}
}
