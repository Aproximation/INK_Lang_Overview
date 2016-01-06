var fruits = ["mango", "kiwi", "avocado"]
fruits.append("banan")
for var index = 0; index < fruits.count; ++index {
	print("Fruit number \(index) is \(fruits[index])")
}

// Functions and methods are both declared with the
// "func" syntax, and the return type is specified with ->
func sayHello(personName: String) -> String {
    let greeting = "Hello, \(personName)!"
    return greeting
}

