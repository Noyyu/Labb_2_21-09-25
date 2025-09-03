namespace Labb_2_21_09_25
//Nikki Norberg, SUT25
{
    internal class program
    {
        static void Main(string[] args)
        {
            int randomNumber = new Random().Next(0, 20); //Skaffar ett "slumpmässigt" nummer (baserad på tid applikationen öppnades) mellan 0 och 20. (talet kan vara både 0 och 20). 
            int guess = -1;
            int försök = 0;


            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 0 och 20, kan du gissa vilket?");
            Console.WriteLine("Du får 5 försök.. :)");


            //--------------------------------------------------------------------------------------------------------------
            // Har man svarat rätt, inte har några försök kvar eller man triggrat exit boolen så stannar man i while loopen.
            //--------------------------------------------------------------------------------------------------------------
            while (guess != randomNumber && försök < 4)
            {
                // ------------------------------------------------------------------------------------------------------------
                // Sätter variabeln "försök" till 0 EN gång. Den läser sedan de två andra raderna för varje itteration.
                // I detta exempel plussar den på 1 på "försök" FÖRE den kollar ifall "försök" är < 5. 
                // Därför skickar jag ut användaren ur ProcessGuess metoden vid 4 försök (då vi börjar på 0 försök och inte 1). 
                // ------------------------------------------------------------------------------------------------------------
                for (försök = 0 ; försök < 5; försök++)
                {

                    //----------------------------------
                    // Om användaren matar in en siffra.
                    //----------------------------------
                    if (int.TryParse(Console.ReadLine(), out guess))
                    {                      
                        försök = ProcessGuess(guess, randomNumber, försök); //"Försök" ändras i funktionen för att man ska kunna fly for loopen. 
                    }

                    //-------------------------------------------------
                    // Om användaren matar in något annat än en siffra. 
                    //-------------------------------------------------
                    else
                    {
                        if (försök == 4)
                        {
                            Console.WriteLine("Fel! Slut på försök! Jag tänkte på " + randomNumber + "!");                           
                        }
                        else
                        {                           
                            Console.WriteLine("Var vänlig mata in ett svar baserat på INSTRUKTIONERNA. Det där räknades som en gissning btw ;)"); //Hade jag viljat att detta INTE skulle räknas som ett försök hade jag lagt till försök++ under denna rad, men detta är roligare. 
                            Console.WriteLine();
                        }
                    }
                }  
            }

        }
        //Methods
        static int ProcessGuess(int guess, int goal, int försök)
        {
            //--------------------------------
            // Om gissningen va högre än målet
            //--------------------------------
            if (guess > goal)
            {

                //-------------------------------------------------------------------
                // Kollar så att man har några försök kvar, om inte kastar den ut dig
                //-------------------------------------------------------------------
                if (försök == 4)
                {
                    Console.WriteLine("Fel! Slut på försök! Jag tänkte på " + goal + "!");                  
                    return försök;
                }
                else
                {
                    Console.WriteLine("Lite lägre~");
                    Console.WriteLine();
                    return försök;
                }

            }
            //--------------------------------
            // Om gissningen va lägre än målet
            //--------------------------------
            else if (guess < goal)
            {

                //-------------------------------------------------------------------
                // Kollar så att man har några försök kvar, om inte kastar den ut dig
                //-------------------------------------------------------------------
                if (försök == 4)
                {
                    Console.WriteLine("Fel! Slut på försök! Jag tänkte på " + goal + "!");
                    return försök; 
                }
                else
                {
                    Console.WriteLine("Lite högre~");
                    Console.WriteLine();
                    return försök;
                }
            }

            //----------------------------------------------------------------------------------------------------------------
            // Om svaret va rätt får användaren veta det och antalet försök ökas till över 5 för att hoppa ut ur försöksloopen
            //----------------------------------------------------------------------------------------------------------------
            else
            {
                Console.WriteLine("Bra jobbat! Svaret va mycket riktigt " + goal + "!");
                försök = 100; //flyr for loopen.
                return försök;
            }
        }
    }
}
