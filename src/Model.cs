/*
Copyright 2022 ItzzCode

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License. 
*/

namespace Program {

	/// <summary>
	/// Collection of varibles and methods for AI things.
	/// </summary>
	class Model {
		static Random rnd = new Random();
		public char[] memory;

		public short[] lookupResponse = new short[500];
		public string[] lookupSearch = new string[500];
		

		public Model( char[] aMemory ) {
			memory = aMemory;
		}

		/// <summary>
		/// 	Given an array of chars (such as the model's memory), randomly change it `heat` times.
		/// </summary>
		/// <param name="mem"></param>
		/// <param name="heat"></param>
		/// <returns>Mutated array of chars.</returns>
		static public char[] mutate( char[] mem, short heat ) {
			for( int i = 0; i < heat; i++ ) {
				mem[rnd.Next(999)] = (char)rnd.Next(0x20, 0x7F); //range of printable ascii
			}
			return mem;
		}

		/// <summary> 
		///		Given an input, return a string from memory based on lookupSearch and lookupResponse.
		/// </summary>
		/// <param name="input"></param>
		/// <returns>String of at most 10 characters.</returns>
		public string? respond( string input ) {
			//find index of the response in lookupSearch
			int responseLocation = Array.FindIndex(lookupSearch, element => element == input.ToLower());

			//check if it was there
			if( responseLocation == -1 ){
				//if not, add the input to lookupSearch
				responseLocation = rnd.Next(499);
				lookupSearch[responseLocation] = input;
				lookupResponse[responseLocation] = (short)rnd.Next(499);
			}
			
			//return the appropriate response that coresponds to the lookupSearch index
			string? returnText = memory[lookupResponse[responseLocation]].ToString();
			for( int k = 0; k < 10; k++ ) {
				//if memory ends before we get 10 chars, break and return what did make it
				try { returnText += memory[responseLocation+k]; }
				catch (System.IndexOutOfRangeException) {	
					break;
				}
			}
			return returnText;
		}

	}
}