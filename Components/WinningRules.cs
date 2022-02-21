namespace RockPaperScissors.Components
{
    public class WinningRules
    {
        //CREAR UNA LISTA DE TUPLES
        private readonly IList<(int, int, bool, bool, string)> winningRules = new List<(int, int, bool, bool, string)> 
        {
            //EL PRIMER VALOR REPRESENTA LA ELECCION DEL JUGADOR
            //EL SEGUNDO VALOR REPRESENTA LA ELECCION DEL COMPUTADOR
            //EL TERCER VALOR INDICA QUE EL JUGADOR HA GANADO
            //EL CUARTO VALOR INDICA QUE EL COMPUTADOR HA GANADO
            //EL ULTIMO VALOR INDICA EL MENSAJE QUE SERA MOSTRADO EN PANTALLA

            //ROCA
            (0, 0, false, false, "Ambos eligieron ROCA, es EMPATE"),
            (0, 1, false, true, "PAPEL vence ROCA, tú PIERDES"),
            (0, 2, true, false, "ROCA vence TIJERA, tú GANAS"),
            //PAPEL
            (1, 0, true, false, "PAPEL vence ROCA, tú GANAS"),
            (1, 1, false, false, "Ambos eligieron PAPEL, es EMPATE"),
            (1, 2, false, true, "TIJERA vence PAPEL, tú PIERDES"),
            //TIJERA
            (2, 0, false, true, "ROCA vence TIJERA, tú PIERDES"),
            (2, 1, true, false, "TIJERA vence PAPEL, tú GANAS"),
            (2, 2, true, false, "Ambos eligieron TIJERA, es EMPATE"),
        };

        //PARA MOSTRAR EL GANADOR USAR UN INDEXER
        //PASAR LA ELECCION DEL JUGADOR Y DEL COMPUTADOR
        //PARA RECIBIR AL GANADOR
        public (int, int, bool, bool, string) this[int playerChoice, int computerChoice]
        => winningRules.Single(w => w.Item1 == playerChoice && w.Item2 == computerChoice);
    }
}