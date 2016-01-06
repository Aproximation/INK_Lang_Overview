puts "Hello World!"

//Using C#
using System;
using System.Collection;

Hastable openWith = new Hashtable();
openWith.Add("txt","notepad.exe");
openWith.Add("bmp","paint.exe");
openWith.Add("rtf","wordpad.exe");

//using Ruby on Rails
openWith = {
	txt: "notepad.exe",
	bmp: "paint.exe",
	rtf: "wordpad.exe",
}


 @todo_array = [ "Buy Milk", "Buy Soap", "Pay bill", "Draw Money" ]


 <ul>
  <% @todo_array.each do |t| %>
   <li> <% t %>  </li>
   <% end %>
</ul>