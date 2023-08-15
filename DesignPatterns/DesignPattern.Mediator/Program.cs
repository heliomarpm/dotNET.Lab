using System;

namespace DesignPattern.Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            //'Cria uma sala de chat (chatsala) 
            var sala = new ChatSala();

            //' cria participantes e faz o registro             
            Participante heliomar = new Membro("Heliomar");
            Participante angelina = new Membro("Angelina");
            Participante lazaro = new Membro("Lázaro");
            Participante laura = new Membro("Laura");
            Participante piolho = new NaoMembro("Piolho");

            //'registra os participantes 
            sala.Registro(heliomar);
            sala.Registro(angelina);
            sala.Registro(lazaro);
            sala.Registro(laura);
            sala.Registro(piolho);

            //' Inicia o chat 
            heliomar.Enviar("Angelina", "Olá, Angelina!");
            lazaro.Enviar("Laura", "Oi Laurinha");
            piolho.Enviar("Laura", "Oi afim de tc?");
            laura.Enviar("Piolho", "sai fora piolho");
            angelina.Enviar("Heliomar", "Oi amor, tudo bem");

            Console.ReadKey();
        }
    }
}
