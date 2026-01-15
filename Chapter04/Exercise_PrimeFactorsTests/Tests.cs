using Exercise_PrimeFactorsLib;

namespace Exercise_PrimeFactorsTests
{
    public class Tests
    {
        [Fact]
        public void Test99()
        {
            // Arrange: settare gli input e le uscite
            int number = 99;
            string expected = "11 x 3 x 3 ";

            //Act: Eseguire il test della funzione
            string actual = PrimeFactorsLib.PrimeFactors(number);

            //Assert: Comparare ciò che mi aspetto con il valore attuale
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test10()
        {
            //Arrange
            int number = 10;
            string expected = "5 x 2 ";

            //Act
            string actual = PrimeFactorsLib.PrimeFactors(number);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]

        //Chiedere a Fabio come faccio a fare un test se nella classe gestisco l'errore con un try-catch
        public void Test1001()
        {
            //Arrange
            int number = 1001;
            string expected = "Il numero deve essere compreso tra 1 e 1000.";

            //Act
            string actual = PrimeFactorsLib.PrimeFactors(number);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
    