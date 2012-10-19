#pragma once
#include "System/System.h"
#include "CovIEnumerable_T.h"
#include "CovIEnumerator_T.h"
#include "System/Console.h"
#include "B_T.h"

using namespace System;
namespace Covariance {
	namespace _Internal {

		//The classes defined in namespace _Internal are internal types.
		//DO NOT modify this code

		template<typename T>
		class A_T_Base : public virtual CovIEnumerable_T<TypeArg(T)>, public virtual Object, public virtual gc_cleanup{
			public:
			CovIEnumerator_T<TypeArg(T)>* Get(){
				Console::WriteLine(new String("A<T>.Get()"));
				return new Covariance::B_T<TypeArg(T)>();
			}
			public:
			A_T_Base()
			{
			}
		};

		template<typename T, bool>
		class A_T  {
		};

		//Basic types template type
		template<typename T>
		class A_T<T, true> : public A_T_Base<T>{
		};

		//Generic template type
		template<typename T>
		class A_T<T, false> : public virtual A_T_Base<Object*> {			
			public:
			template<typename U>
			class A_adapter
			{
				public:
				static inline CovIEnumerator_T<U>* Get(){
					Object* var_tmp = A_T_Base<Object*>::Get();
					return dynamic_cast<CovIEnumerator_T<U>*>(var_tmp);
				}
			};		
			
			public:
			inline CovIEnumerator_T<Object>* Get(){				
				return dynamic_cast<CovIEnumerator_T<Object>*>(A_adapter<T>::Get());
			}
		};
	}

	//Type definition
	template<typename T>
	class A_T : public _Internal::A_T<T, IsBasic(T)>{
	};
}