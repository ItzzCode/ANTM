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
	class Program {
		static void Main() {
			string? input;
			bool running = true;

			short radiation = 200;


			//initialize 3 model objects.
			var modelNo1 = new Model(new char[1000]);
			modelNo1.memory = Model.mutate(modelNo1.memory, 10000);

			var modelNo2 = new Model(new char[1000]);
			modelNo2.memory = Model.mutate(modelNo2.memory, 10000);

			var modelNo3 = new Model(new char[1000]);
			modelNo3.memory = Model.mutate(modelNo3.memory, 10000);
			
			while( running ) {
				Console.WriteLine("Enter an input.");
				//take input, and set to empty string if null.
				input = Console.ReadLine();
				if( input == null ){ input = ""; }

				//models respond to input
				Console.WriteLine($"Model 1: {modelNo1.respond(input)}");
				Console.WriteLine($"Model 2: {modelNo2.respond(input)}");
				Console.WriteLine($"Model 3: {modelNo3.respond(input)}\n");

				//ask user which one was best
				//THIS CAN BE DONE BETTER, I JUST DONT WANNA NOW
				gotoTime:

				int input2;
				try {
				Console.WriteLine("Type in the number of the model that was best!");
				input2 = Convert.ToInt32(Console.ReadLine());
				} catch {
					goto gotoTime;
				}

				//interpret input
				switch( input2 ) {
					case 0:
						running = false;
						break;

					case 1:
						modelNo2.memory = Model.mutate(modelNo1.memory, radiation);
						modelNo2.lookupSearch = modelNo1.lookupSearch;
						modelNo2.lookupResponse = modelNo1.lookupResponse;

						modelNo3.memory = Model.mutate(modelNo1.memory, radiation);
						modelNo3.lookupSearch = modelNo1.lookupSearch;
						modelNo3.lookupResponse = modelNo1.lookupResponse;
						break;
					
					case 2:
						modelNo1.memory = Model.mutate(modelNo2.memory, radiation);
						modelNo1.lookupSearch = modelNo2.lookupSearch;
						modelNo1.lookupResponse = modelNo2.lookupResponse;

						modelNo3.memory = Model.mutate(modelNo2.memory, radiation);
						modelNo3.lookupSearch = modelNo2.lookupSearch;
						modelNo3.lookupResponse = modelNo2.lookupResponse;
						break;
					
					case 3:
						modelNo1.memory = Model.mutate(modelNo3.memory, radiation);
						modelNo1.lookupSearch = modelNo3.lookupSearch;
						modelNo1.lookupResponse = modelNo3.lookupResponse;

						modelNo2.memory = Model.mutate(modelNo3.memory, radiation);
						modelNo2.lookupSearch = modelNo3.lookupSearch;
						modelNo2.lookupResponse = modelNo3.lookupResponse;
						break;

					case 20:
						
					
					default:
						goto gotoTime;
				}
				
			}
			
		}
	}
}