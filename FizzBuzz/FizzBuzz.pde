String three = "Fizz";
String five = "Buzz";


for (int i = 1; i <= 100; i++){
	if (i % 3 == 0)
	{		
		if (i % 5 == 0)
		{
			println(three + five);
		}
		else{
			println(three);
		}		
	}
	else if (i % 5 == 0){
		println(five);
	}
	
	else{
			println(i);
	}
}