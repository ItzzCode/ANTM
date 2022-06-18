# ,Adversarial Network Thing Machine?
## its a Thing

It makes 3 models, ask you which is best, and copies the best one

### how to build
build with any C# compiler (tested with .NET though)

### how it works
a model has a 1000 char array of memory, which can be mutated by passing the memory into the mutate method

it also has a lookup 

lookupSearch has a list of strings, when you give a model an input through the respond method, it looks if your input is in there (if not it adds it)

lookupResponse is an array of shorts, when a match is made in lookupSearch, it goes here to see where it points to in the memory

the program makes 3 models, and when you feed it an input, it makes the 3 output their response

whichever you chose to be the best gets cloned to the others with some radiation

repeat until good

### does it work
no