using System.ComponentModel.Design;

namespace Labb_2_21_09_25
//Nikki Norberg, SUT25
{
    internal class program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (exit == false)
            {
                int randomNumber    = -1;   
                int guessesUsed     = -1;   // Hur många gissningar användaren har använt
                int totalGuesses    = -1;   // Total mängd gissningar
                int userGuess       = -1;   // Nummret användaren gissar på


                ChooseDifficoulty(ref randomNumber, ref totalGuesses);

                //------------------------------------------------------------------------------------
                // Har man svarat rätt eller inte har några försök kvar blir man utkastad från loopen.
                //------------------------------------------------------------------------------------
                while (userGuess != randomNumber && guessesUsed < totalGuesses)
                {
                    // ---------------------------------------------------------------------------------------------------------
                    // Sätter variabeln "guessesUsed" till 0 EN gång. Den läser sedan de två andra raderna för varje itteration.
                    // I detta exempel plussar den på 1 på "guessesUsed" FÖRE den kollar ifall "guessesUsed" är < totalGuesses. 
                    // ---------------------------------------------------------------------------------------------------------
                    for (guessesUsed = 0; guessesUsed < totalGuesses; guessesUsed++)
                    {

                        //------------------------------------------------------------------------------------------------------------
                        // kollar så att användaren matar in en siffra innan den skickar vidare svaret till "ProcessGuess" funktionen.
                        //------------------------------------------------------------------------------------------------------------
                        if (int.TryParse(Console.ReadLine(), out userGuess))
                        {
                            guessesUsed = ProcessGuess(userGuess, randomNumber, guessesUsed, totalGuesses); //Metoden retunerar en int, först baserad på guessesUsed, men som kan ändras i funktionen för att fly loopen.
                        }

                        //-------------------------------------------------
                        // Om användaren matar in något annat än en siffra. 
                        //-------------------------------------------------
                        else
                        {
                            if (guessesUsed == (totalGuesses - 1))
                            {
                                Console.WriteLine("Fel! Slut på försök! Jag tänkte på " + randomNumber + "!");
                            }
                            else
                            {
                                Console.WriteLine(RandomizedAnswer(3) + " Det där räknades som en gissning btw ;)"); //Hade jag viljat att detta INTE skulle räknas som ett försök hade jag lagt till guessesUsed++ under denna rad, men detta är roligare. 
                                Console.WriteLine();
                            }
                        }
                    }
                }

                //-----------------------
                // Min lilla avslutsmeny.
                //-----------------------
                Console.WriteLine();
                Console.WriteLine("Vill du leka igen?");
                Console.WriteLine("1: Ja");
                Console.WriteLine("2: Nej");
                int continnue = 0;

                while (continnue == 0)
                {
                    if (int.TryParse(Console.ReadLine(), out continnue))
                    {
                        if (continnue == 1)
                        {
                            exit = false;
                            Console.Clear();
                            Console.WriteLine("Då då Fortsätter vi!");
                            Console.WriteLine();
                        }
                        else
                        {
                            exit = true;
                            Console.Clear();
                            Console.WriteLine("Då ses vi senare, hejdå!");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        continnue = 0; //Jag har märkt att även om TryParse misslyckas så stoppar den in något konstigt i out variabeln, där av varför jag resettar den här inne.  
                        Console.WriteLine("Välj 1 eller 2.");
                    }
                }
            }
        }

        //Methods
        
        //------------------------------------------------------------------------------------------
        // Kollar om användaren matade in ett giltigt svar och om -
        // 1: det är fel får användaren veta det och om det är för stort eller för litet, eller om -
        // 2: det är rätt får användaren veta det och man hoppar ut ur loopen
        //------------------------------------------------------------------------------------------
        static int ProcessGuess(int userGuess, int randomNumber, int usedGuesses, int totalGuesses)
        {
            //--------------------------------
            // Om gissningen va högre än målet
            //--------------------------------
            if (userGuess > randomNumber)
            {

                //-------------------------------------------------------------------
                // Kollar så att man har några försök kvar, om inte kastar den ut dig
                //-------------------------------------------------------------------
                if (usedGuesses == (totalGuesses - 1))
                {
                    Console.WriteLine("Fel! Slut på försök! Jag tänkte på " + randomNumber + "!");
                    return usedGuesses;
                }
                else
                {
                    Console.WriteLine(RandomizedAnswer(2));
                    if (userGuess == (randomNumber + 1))
                    {
                        Console.WriteLine("Men nu är det väääldigt nära!");
                    }
                    Console.WriteLine();
                    return usedGuesses;
                }
            }
            //---------------------------------
            // Om gissningen va lägre än målet.
            //---------------------------------
            else if (userGuess < randomNumber)
            {

                //--------------------------------------------------------------------
                // Kollar så att man har några försök kvar, om inte kastar den ut dig.
                //--------------------------------------------------------------------
                if (usedGuesses == (totalGuesses - 1))
                {
                    Console.WriteLine("Fel! Slut på försök! Jag tänkte på " + randomNumber + "!");
                    return usedGuesses;
                }
                else
                {
                    Console.WriteLine(RandomizedAnswer(1));
                    if (userGuess == (randomNumber - 1))
                    {
                        Console.WriteLine("Men nu är det väääldigt nära!");
                    }
                    Console.WriteLine();
                    return usedGuesses;
                }
            }

            //-----------------------------------------------------------------------------------------------------------------
            // Om svaret va rätt får användaren veta det och antalet försök ökas till över 5 för att hoppa ut ur försöksloopen.
            //-----------------------------------------------------------------------------------------------------------------
            else
            {
                Console.WriteLine("Bra jobbat! Svaret va mycket riktigt " + randomNumber + "!");
                usedGuesses = 100; //flyr for loopen.
                return usedGuesses;
            }
        }

        //--------------------------------------------------------------------------------------------------------------
        // Låter användaren välja svårighetsgrad
        // Jag använder ref int i denna fuktionen för att jag har som avsikt att ändra på variablerna inne i funktionen. 
        //--------------------------------------------------------------------------------------------------------------
        static void ChooseDifficoulty(ref int randomNumber, ref int guesses)
        {
            randomNumber      = -1;
            guesses           = -1;
            int difficulty    = -1; //Jag allokerar minne om jag vill det >:(
            int choiceDisplay = -1;

            Console.WriteLine("Välj svårighetsgrad!");
            Console.WriteLine("1: Lätt");
            Console.WriteLine("2: Normalt");
            Console.WriteLine("3: Svårt");
            Console.WriteLine("4: Custom");

            //-----------------------------------------------------------------------------
            // Kollar så att användaren skriver in ett tal och att talet är mellan 1 och 4.  
            //-----------------------------------------------------------------------------
            while (int.TryParse(Console.ReadLine(), out difficulty) == false || (difficulty > 4 || difficulty < 1)) // Jag kan inte få till || på mitt skrivbord så jag fick kopiera dom från nätet
            {
                Console.WriteLine(RandomizedAnswer(3));
            }


            switch (difficulty)
            {
                case 1:

                    randomNumber = new Random().Next(0, 10);
                    guesses = 5;

                    Console.Clear();
                    Console.WriteLine("Du valde svårighetsgrad: Lätt!");
                    Console.WriteLine("Jag tänker på ett tal mellan 0 och 10, kan du gissa vilket?");
                    Console.WriteLine("Du har 5 försök~ :) ");
                    break;

                case 2:
                    randomNumber = new Random().Next(0, 20);
                    guesses = 5;
                    Console.Clear();
                    Console.WriteLine("Du valde svårighetsgrad: Normalt!");
                    Console.WriteLine("Jag tänker på ett tal mellan 0 och 20, kan du gissa vilket?");
                    Console.WriteLine("Du har 5 försök~ :) ");
                    break;

                case 3:
                    randomNumber = new Random().Next(0, 50);
                    guesses = 5;
                    Console.Clear();
                    Console.WriteLine("Du valde svårighetsgrad: Svårt!");
                    Console.WriteLine("Jag tänker på ett tal mellan 0 och 50, kan du gissa vilket?");
                    Console.WriteLine("Du har 5 försök~ :) ");
                    break;

                case 4:

                    Console.WriteLine("Välj hur högt taket kan vara, där 0 är det minsta talet.");

                    //-------------------------------------------------------------------
                    // Ber användaren mata in hur många nummer hen ska kunna välja bland.
                    //-------------------------------------------------------------------
                    while (randomNumber == -1)
                    {
                        if (int.TryParse(Console.ReadLine(), out randomNumber))
                        {
                            choiceDisplay = randomNumber;
                            randomNumber = new Random().Next(0, randomNumber);

                            Console.WriteLine("Coolt! Nu, välj hur många försök du vill ha.");
                        }
                        else
                        {
                            Console.WriteLine(RandomizedAnswer(3));
                            randomNumber = -1;
                        }
                    }

                    //------------------------------------------------------
                    // Ber användaren mata in hur många försök hen skall få.
                    //------------------------------------------------------
                    while (guesses == -1)
                    {
                        if (int.TryParse(Console.ReadLine(), out guesses))
                        {
                            Console.WriteLine("Okej! i så fall..");
                            Console.WriteLine("Jag tänker på ett tal mellan 0 och " + choiceDisplay + ", Kan du gissa vilket?");
                            Console.WriteLine("Du har " + guesses + " försök~ :)");
                        }
                        else
                        {
                            Console.WriteLine(RandomizedAnswer(3));
                            guesses = -1;
                        }
                    }
                    break;
            }// End of switch case
        }

        //-------------------------------------------------------------------------------------------------------------
        // En "typ" slumpmässigt svar generator! 
        // Du matar in en int som representerar vilket typ av svar du vill ha, sen får du ett av 4 svar som passar det.
        //-------------------------------------------------------------------------------------------------------------
        static string RandomizedAnswer(int answerType)
        {
            int random = new Random().Next(0, 3);

            string[] förLitet = new string[4]; //Arrays börjar på 0, Arrays börjar på 0, Arrays börjar på 0, Arrays börjar på 0, Arrays börjar på 0, Arrays börjar på 0, Arrays börjar på 0, Arrays börjar på 0, Arrays börjar på 0, Arrays börjar på 0
            string[] förStort = new string[4];
            string[] fel = new string[4];

            förLitet[0] = "För litet!";
            förLitet[1] = "Lite för litet!";
            förLitet[2] = "Talet jag tänker på är större än så, försök igen!";
            förLitet[3] = "Större!";

            förStort[0] = "Lite för stort!";
            förStort[1] = "För stort!";
            förStort[2] = "Talet jag tänker på är mindre än så";
            förStort[3] = "Mindre!";

            fel[0] = "Var vänlig följ instruktionerna..";
            fel[1] = "Gör om, gör rätt.";
            fel[2] = "Snälla läs vad det står..";
            fel[3] = "Läs INSTRUKTIONERNA och välj ett alternativ... :)";

            if (answerType == 1)
            {
                return förLitet[random];
            }
            if (answerType == 2)
            {
                return förStort[random];
            }
            if (answerType == 3)
            {
                return fel[random];
            }
            return ""; //Denna kommer aldrig användas men funktionen blir sur på mig om jag inte har den.
        }
    }
}
