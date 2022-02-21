using Microsoft.AspNetCore.Components;
using RockPaperScissors.Components;

namespace RockPaperScissors.Components
{
    // CONTIENE LA LOGICA RELACIONADO A LA COMPONENTES DEL JUEGO
    public partial class Game
    {
        // CREAR LAS VARIABLES RELACIONADOS PARA MOSTRAR LOS SCORE, LAS IMAGENES Y EL MENSAJE
        private int playerScore;
        private int computerScore;
        private string playerChoiceImage;
        private string computerChoiceImage;
        private string message;

        //UNA VEZ QUE EL JUGADOR HA JUGADO ES EL TURNO DEL COMPUTADOR,
        //UNA VEZ QUE EL COMPUTADOR HA JUGADO,
        //EL SCORE SERA MOSTRADO
        //ESTAS ACCIONES RECONSTRUYEN LOS ESTADOS DEL JUEGO
        //MODELAMOS LOS ESTADOS USANDO 3 DELEGATES

        //ESTE METODO MANEJA EL ESTADO DEL JUEGO CUANDO EL JUGADOR HA JUGADO
        private readonly Action<int> playerMadeChoice;
        //ESTE METODO MANEJA EL ESTADO DEL JUEGO CUANDO EL COMPUTADOR COMIENZA A JUGAR
        private readonly Action<int> computerMadeChoice;
        //ESTE METODO MANEJA EL ESTADO DEL JUEGO CUANDO EL JUGADOR Y EL COMPUTADOR HACEN UNA ELECCION
        private readonly Action<int, int> bothMadeChoice;

        //CLASE RANDOM PARA LA DECISION DEL COMPUTADOR
        private readonly Random random;

        public Game()
        {
            //INICIALIZAR LA VARIABLE RANDOM
            random = new Random();

            playerMadeChoice = (playerChoice) => 
            {
                //RECIBIR LA ELECCION DEL JUGADOR EN FORMA DE UN NUMERO ENTRE 1 Y 2
                //MOSTRAR LA IMAGEN RELACIONADO A LA ELECCION 
                playerChoiceImage = choices[playerChoice];
                //INVOCAR LA SIGUIENTE ACCION
                computerMadeChoice(playerChoice);
            };

            computerMadeChoice = (playerChoice) => 
            {
                //LA DECISION DEL COMPUTADOR SERA GENERADO POR UNA CLASE RANDOM
                //GENERAR UN NUMERO ENTRE 0 Y 2
                var computerChoice = random.Next(2);
                //MOSTRAR LA IMAGEN RELACIONADO A LA ELECCION AND INVOCAR LA SIGUIENTE ACCION
                computerChoiceImage = choices[computerChoice];
                //NOTIFICAR AL COMPONENTE QUE TIENE QUE RENDERIZAR
                StateHasChanged();

                //INVOCAR LA SIGUIENTE ACCION
                bothMadeChoice(playerChoice, computerChoice);

            };

            bothMadeChoice = (playerChoice, computerChoice) =>
            {
                //EN LA SIGUIENTE ACCION RECIBIR LA ELECCION DE EL JUGADOR Y EL COMPUTADOR
                //Y TENEMOS QUE ELEGIR EL GANADOR
                //PARA DEFINIR EL GANADOR CREAR LA CLASE WINNINGRULES
                var (_, _, playerWon, computerWon, message) = WinningRules[playerChoice, computerChoice];
                //MENSAJE GANADOR
                this.message = message;
                //MOSTRAR EL SCORE DEL JUGADOR Y DEL COMPUTADOR
                playerScore = playerWon ? ++playerScore : playerScore;
                computerScore = computerWon ? ++computerScore : computerScore;

                 //NOTIFICAR AL COMPONENTE QUE TIENE QUE RENDERIZAR
                StateHasChanged();
            };
        }

        // CUANDO EL COMPONENTE SEA INICIADO, MOSTRARA UN MENSAJE QUE IINVITE AL JUGADOR A JUGAR
        protected override void OnInitialized() => SetDefaultMessage();
        private void SetDefaultMessage() => message = "¡Elige; piedra, papel o tijera!";

        //PARA JUGAR, EL JUGADOR DEBE HACER CLIC EN UNA IMAGEN, PARA ELLO AGREGAR EL METODO "OnPlayerMadeChoice()"
        //ESTE METODO SERA EJECUTADO EN RESPUESTA A UN CLIC EN LA IMAGEN
        //INVOCAR PLAYERMADECHOICE PARA INICIAR LA SECUENCIA DEL JUEGO
        private void OnPlayerMadeChoice(int playerChoice) => playerMadeChoice(playerChoice);

        //LOGICA PARA EL BOTON DE RESTABLECER EL JUEGO
        private void Reset()
        {
            //RESTABLECER EL MENSAJE DEL JUEGO
            SetDefaultMessage();
            //RESTABLECER EL SCORE DEL JUEGO
            playerScore = computerScore = 0;
            //RESTABLECER LAS IMAGENES DEL JUEGO
            playerChoiceImage = computerChoiceImage = string.Empty;
        }

        //INJECTAR LA CLASE WINNINGRULES
        [Inject]
        public WinningRules WinningRules { get; set; }
    }
}