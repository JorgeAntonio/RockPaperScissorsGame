namespace RockPaperScissors.Components
{
    public class Choices
    {
        //CREAR UN DICCIONARIO PARA DIFINIR LAS POSIBILIDADES DE 0 A 2 RELACIONADO CON UN IMAGEN
        private readonly Dictionary<int, string> choices = new Dictionary<int, string>
        {
            {0,"✊"},
            {1,"🤚"},
            {2,"✌️"}
        };

        //RECIBE EL STRING QUE REPRESENTA LA IMAGEN EN EL DICCIONARIO HACER USO DE UN INDEX
        public string this[int choiceKey] => choices[choiceKey];
    }
}