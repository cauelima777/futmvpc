﻿using System;
using System.Diagnostics;

class Program
{


    //INICIAR O PROGRAMA
    static void Main(string[] args)
    {
        bool jogarNovamente = true;
        

        while (jogarNovamente)
        {
            LimparTela();

            JogoFutebol jogo = new JogoFutebol();
            jogo.IniciarJogo();

            Console.WriteLine("Deseja jogar novamente? (S/N)");
            string resposta = Console.ReadLine();
            jogarNovamente = (resposta.ToUpper() == "S");
        }
    }

    //LIMPAR A TELA
    static void LimparTela()
    {
        
        Console.Clear();
    }
}


    class JogoFutebol
    {
        private Jogador jogador;
        private Jogador jogador2;
        private Computador computador;


        private bool jogarNovamente;
        private int golsJogador1 = 0;
        private int golsJogador2 = 0;
        private int pontosJogador1 = 0;
        private int pontosJogador2 = 0;

        private int energiaJogador;
        private int energiaComputador;

        private int golsJogador;
        private int golsComputador;

        private int resp;

        private int opcaoDesempate;

        private void LimparTela()
        {
            Console.Clear();
        }

        public JogoFutebol()
        {
            jogador = new Jogador();
            jogador2 = new Jogador();
            computador = new Computador();
        }

        static void DrawLoadingBar(int percentage)
        {
            Console.Write("Carregando... ");

            int progressBarLength = 20;
            int progress = (int)Math.Ceiling(progressBarLength * percentage / 100.0);

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string('█', progress));
            Console.Write(new string(' ', progressBarLength - progress));
            Console.Write($"] {percentage}%\r");
            Console.ResetColor();
        }

        static void AsciiArt(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    int contador = 0;
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        contador++;
                        Console.SetCursorPosition(1, contador);
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {e.Message}");
            }
        }


      


        public void IniciarJogo()
        {

   
            int pontosJogador = 0;
            int pontosComputador = 0;
            int golsJogador = 0;
            int golsComputador = 0;

            Console.WriteLine("Loading...");

            for (int i = 0; i <= 100; i += 10)
            {
                DrawLoadingBar(i);
                Thread.Sleep(200);
                 if (i == 20)
                {
                    LimparTela();
                    AsciiArt("asci4.txt");
                }
                else if (i == 50)
                {
                    LimparTela();
                    AsciiArt("asci5.txt");
                }else if (i== 100)
                { 
                    LimparTela();
                }
            }   

            Console.ForegroundColor = ConsoleColor.Yellow;

            AsciiArt("título2.txt");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Digite o seu nome");
            Console.ResetColor();
            jogador.Nome = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Nome do jogador 2");
            Console.ResetColor();
            jogador2.Nome = Console.ReadLine();

            LimparTela();
            Console.WriteLine("Loading...");

            for (int i = 0; i <= 100; i += 10)
            {
                DrawLoadingBar(i);
                Thread.Sleep(200);

                if (i == 20)
                {
                    LimparTela();
                    AsciiArt("asci3.txt");
                }
             else if (i == 50)
                {
                    LimparTela();
           
                    AsciiArt("asci2.txt");
                   
                }else if (i== 100)
                { 
                    LimparTela();
                }
            }

            LimparTela();
            
           
            AsciiArt("asci.txt");

            
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

    

            LimparTela();

            string[] menuItems = { $"{jogador.Nome } x computador", $"{jogador.Nome} x {jogador2.Nome}", "Créditos", "Como funciona e regras", "Sair" };
            int selectedItemIndex = 0;

            while (true)
            {
                string[] frases = { "'Prefiro ajudar na briga'","Fala zezé'", "'Vocês vão ter que me engolir'", "'Eu sou o milior - Cerrisete'", "'Não é time é seleção'", "'Errei fui mlk'", "'Pelé calado é um poeta'", "'oto patamá'","'Cincum???'"};
            
                Random random = new Random();
                int a = random.Next(0, frases.Length);




                Console.Clear();
        

          
                Console.ForegroundColor = ConsoleColor.Yellow;
                AsciiArt("titulo.txt");

              
   

           
                Console.WriteLine("");

                
        

                Console.ResetColor();
                Console.WriteLine("Obs: Menu controlado pelas setas do teclado ↓-↑");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"                                                                                     {frases[a]}                                ");
                Console.WriteLine("");
                Console.ResetColor();
            

          
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    
                        
                        
                    }

                    Console.WriteLine("                                                                                       " + menuItems[i]);

                    Console.ResetColor();


                  
                }

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItemIndex = (selectedItemIndex - 1 + menuItems.Length) % menuItems.Length;
  
                        break;

                    case ConsoleKey.DownArrow:
                        selectedItemIndex = (selectedItemIndex + 1) % menuItems.Length;
                     
                        break;

                    case ConsoleKey.Enter:

                    //Poderá ser colocado na opção 3
                    if (selectedItemIndex == menuItems.Length - 1) // Verifica se a opção é "Sair"
                    {
                          Console.WriteLine("Até logo!");
                          Environment.Exit(0); // Encerra o programa
                    }else
                        {
                            Console.Clear();
                            OpcaoSelecionada(selectedItemIndex, ref pontosJogador, ref pontosComputador, ref golsJogador, ref golsComputador);
                            Console.ReadLine();
                        }
                                 break;
                }
            }
        }

    private void OpcaoSelecionada(int opcao, ref int pontosJogador, ref int pontosComputador, ref int golsJogador, ref int golsComputador)
{
    resp = opcao; 

    switch (resp)
    {
        case 0:

              pontosJogador = 0; 
              pontosComputador = 0; 
            JogarPartidaContraComputador(ref pontosJogador, ref pontosComputador, ref golsJogador, ref golsComputador);
            ExibirResultado(jogador.Nome, "Computador", golsJogador, golsComputador, pontosJogador, pontosComputador, energiaJogador, energiaComputador);
            ExibirPlacar(jogador.Nome, "Computador", pontosJogador, pontosComputador);
            break;

        case 1:
              pontosJogador = 0; 
              pontosComputador = 0; 
            JogarPartidaEntreJogadores(ref pontosJogador, ref pontosComputador, ref golsJogador, ref golsComputador);
            ExibirResultado(jogador.Nome, jogador2.Nome, golsJogador, golsComputador, pontosJogador, pontosComputador, energiaJogador, energiaComputador);
            ExibirPlacar(jogador.Nome, jogador2.Nome, pontosJogador, pontosComputador);
            break;

        case 2:

        
            ExibirCreditos();
            break;


        case 3: 


                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
  




        Console.ForegroundColor = ConsoleColor.Yellow;
        AsciiArt("figure2.txt");
        Console.ResetColor();

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");


        Console.WriteLine("-Dois jogadores entram com seus nomes.");
        Console.WriteLine("-Sorteia-se quem começa.");

        // Desenvolvimento do Jogo
        Console.WriteLine("\nCada jogador inicia com 10 energias, 0 gols e 0 pontos.");

        // Resolução de Cartas
        Console.WriteLine("\nResolução de Cartas:");
        Console.WriteLine("-Se as três cartas são \"Gol\", o jogador marca um ponto e passa a vez.");
        Console.WriteLine("-Se as três cartas são \"Energia\", o jogador ganha uma energia e passa a vez.");
        Console.WriteLine("-Se as três cartas são \"Pênalti\", o jogador escolhe e o adversário tenta defender.");
        Console.WriteLine("-Se defender, não há gol; se não defender, o jogador marca dois pontos.");
        Console.WriteLine("-Se as três cartas são \"Falta\", o jogador passa a vez.");
        Console.WriteLine("-Se as três cartas são \"Cartão Amarelo\", o jogador perde uma energia.");
        Console.WriteLine("-Se as três cartas são \"Cartão Vermelho\", o jogador perde duas energias.");

        // Pontuação
        Console.WriteLine("\nPontuação:");
        Console.WriteLine("-Gol: 3 pontos.");
        Console.WriteLine("-Pênalti: 2 pontos.");
        Console.WriteLine("-Falta: 1 ponto.");
        Console.WriteLine("-Cartão Amarelo: 1 ponto.");
        Console.WriteLine("-Cartão Vermelho: 0 pontos.");
        Console.WriteLine("-Energia: 2 pontos.");

        // Condições de Vitória ou Empate
        Console.WriteLine("\nCondições de Vitória ou Empate:");
        Console.WriteLine("A partida empata se:");
        Console.WriteLine(" - Número de gols e pontuação são iguais.");
        Console.WriteLine("A partida estabelece o vencedor se:");
        Console.WriteLine(" - Número de energias de ambos os jogadores acabar.");
        Console.WriteLine(" - Um jogador finalizar suas jogadas e o outro ainda tiver energias.");
        Console.WriteLine("Se houver empate, considera-se o número de gols e a pontuação para determinar o vencedor.");


        Console.WriteLine("");
    
              

        Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("Regras");
                Console.WriteLine("\n-Não bata no amiguinho se perder ou o contrário");
                Console.WriteLine("\n-Espere a vez do amiguinho");
                Console.WriteLine("\n-Não é o flamengo que é seleção e sim o Vasco, respeitem o Cruz maltino!");
         Console.ResetColor();

         Console.WriteLine("");

         Console.WriteLine("Aperte ENTER para voltar pro menu inicial");


            
            
            break;  


        case 4:
       
                Console.WriteLine("Saindo");

      

            break;
    }
}
        private  void ExibirCreditos()
        {
            Console.Clear();
            
            for (int i = 0; i <= 100; i += 10)
            {
                DrawLoadingBar(i);
                Thread.Sleep(200);

                if (i == 10)
                {
                    LimparTela();
                    Console.ForegroundColor = ConsoleColor.Green;
                    AsciiArt("deseC.txt");
                    Console.ResetColor();

                }
             else if (i == 50)
                {
                    LimparTela();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    AsciiArt("DeseC2.txt");
                    Console.ResetColor();
                   
                } else if(i == 70){
                    
                    LimparTela();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    AsciiArt("DeseC3.txt");
                    Console.ResetColor();

                }else if (i == 80){
                    LimparTela();
                    AsciiArt("DeseC4.txt");
                }
                else if (i== 100)
                { 
                    LimparTela();
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            AsciiArt("frases4.txt");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("█████████");
            Console.WriteLine("█▄█████▄█");
            Console.WriteLine("█▼▼▼▼▼");
            Console.WriteLine("█ Link do 'criador' do código (Digite 1 para acessar ou 2 para cancelar)");
            Console.WriteLine("█▲▲▲▲▲");
            Console.WriteLine("█████████");
            Console.WriteLine(" ██ ██");
            Console.ResetColor();
            Console.WriteLine("");

            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                AbrirLinkArquivoWord();
            }
            else if (escolha == "2")
            {
                Console.WriteLine("Operação cancelada pelo usuário.");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }

      private    void AbrirLinkArquivoWord()
        {
            string link = "https://xplayb2studio.netlify.app";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c start {link}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao abrir o link: {ex.Message}");
            }
        }




















 //------------------------------------------------------JOGADOR1 X JOGADOR2 -------------------------------------------------------------------------------------
  private void JogarPartidaEntreJogadores(ref int pontosJogador, ref int pontosComputador, ref int golsJogador, ref int golsComputador)
    {
        Random random = new Random();
        int energiaJogador1 = 10;
        int energiaJogador2 = 10;

        pontosJogador = 0; 
        pontosComputador = 0; 

        Console.WriteLine($"{jogador.Nome} foi escolhido para começar primeiro");
        Console.WriteLine("Aperte ENTER para começar");
        Console.ReadLine();

        int sorteComeçar = random.Next(0, 2);

        while (energiaJogador1 > 0 && energiaJogador2 > 0)
        {
            LimparTela();
            ExibirStatus(energiaJogador1, jogador2.Nome, energiaJogador2, pontosJogador, pontosComputador);

                

            Console.WriteLine("\n\n\n");

            // Vez do jogador 1

            if (sorteComeçar == 0){

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Vez de {jogador.Nome}");
            Console.ResetColor();
            
            int[] cartasJogador1 = GerarCartasAleatorias(random);
            int pontos1 = CalcularPontos(cartasJogador1, jogador.Nome, ref energiaJogador1);
            pontosJogador += pontos1;
            energiaJogador1--;

            // Vez do jogador 2
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Vez de {jogador2.Nome}");
            Console.ResetColor();
            
            int[] cartasJogador2 = GerarCartasAleatorias(random);
            int pontos2 = CalcularPontos(cartasJogador2, jogador2.Nome, ref energiaJogador2);
            pontosComputador += pontos2;
            energiaJogador2--;


            } else if (sorteComeçar == 1){

            // Vez do jogador 2
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Vez de {jogador2.Nome}");
            Console.ResetColor();
            
            int[] cartasJogador2 = GerarCartasAleatorias(random);
            int pontos2 = CalcularPontos(cartasJogador2, jogador2.Nome, ref energiaJogador2);
            pontosComputador += pontos2;
            energiaJogador2--;


            // Vez do jogador 1
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Vez de {jogador.Nome}");
            Console.ResetColor();
            
            int[] cartasJogador1 = GerarCartasAleatorias(random);
            int pontos1 = CalcularPontos(cartasJogador1, jogador.Nome, ref energiaJogador1);
            pontosJogador += pontos1;
            energiaJogador1--;
            }
        }

        AtualizarGols(ref golsJogador, ref golsComputador, pontosJogador, pontosComputador);
        Console.WriteLine("Fim de jogo!");
        LimparTela();
        

        if (pontosJogador == pontosComputador)
    {
        if (energiaJogador1 > energiaJogador2)
        {
            Console.WriteLine($"{jogador.Nome} venceu por ter mais energias!");



        Console.WriteLine(" -----------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                                  '._==_==_=_.'");
        Console.WriteLine("                                                  .-\\:      /-.");
        Console.WriteLine("                                                 | (|:.     |) |");
        Console.WriteLine("                                                  '-|:.     |-'");
        Console.WriteLine("                                                    \\::.    /");
        Console.WriteLine("                                                     '::. .'");
        Console.WriteLine("                                                       ) (");
        Console.WriteLine("                                                     _.' '._");
        Console.WriteLine(" ---------------------------------------------------------------------------------------------------------------------");
        Console.ReadLine();

        Environment.Exit(0);
           LimparTela();

        }
        else if (energiaJogador2 > energiaJogador1)
        {
            Console.WriteLine($"{jogador2.Nome} venceu por ter mais energias!");


        Console.WriteLine(" --------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                                 '._==_==_=_.'");
        Console.WriteLine("                                                 .-\\:      /-.");
        Console.WriteLine("                                                | (|:.     |) |");
        Console.WriteLine("                                                 '-|:.     |-'");
        Console.WriteLine("                                                   \\::.    /");
        Console.WriteLine("                                                    '::. .'");
        Console.WriteLine("                                                      ) (");
        Console.WriteLine("                                                    _.' '._");
        Console.WriteLine(" --------------------------------------------------------------------------------------------------------------------");

        


        Console.ReadLine();

        Environment.Exit(0);
          LimparTela();
        }
   
    }
    else
    {
        Console.WriteLine("Fim de jogo!");
    }
    }
































    //------------------------------------------------------COMPUTADOR X JOGADOR-------------------------------------------------------------------------------------
    private void JogarPartidaContraComputador(ref int pontosJogador, ref int pontosComputador, ref int golsJogador, ref int golsComputador)
    {
        Random random = new Random();
        int energiaJogador = 10;
        int energiaComputador = 10;

        
                int sorteComeçar = random.Next(0, 2);


        
            

        
        Console.WriteLine("Aperte ENTER para começar");
        Console.ReadLine();

        while (energiaJogador > 0 && energiaComputador > 0)
        {
            LimparTela();
            ExibirStatus(energiaJogador, "Computador", energiaComputador, pontosJogador, pontosComputador);

            Console.WriteLine("\n\n\n");

            //-----------------------------------Vez do jogador de jogar ***FEITO-------------------------------------------------------
            
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Vez de {jogador.Nome}");
            Console.ResetColor();
            Console.ReadLine();
            int[] cartasJogador = GerarCartasAleatorias(random);
            int pontos = CalcularPontos(cartasJogador, jogador.Nome, ref energiaJogador);
            pontosJogador += pontos;

            //-------------------------Reduzir energia do jogador após escolha ***FEITO-------------------------------------------------\\
            energiaJogador--;

            //--------------------------------------------------------------------------------------------------------------------------\\




            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Vez do Computador");
            Console.ResetColor();


            int[] cartasComputador = GerarCartasAleatorias(random);
            int pontosComp = CalcularPontos(cartasComputador, "Computador", ref energiaComputador);
            pontosComputador += pontosComp;

        
            energiaComputador--;

    
            
        }
        AtualizarGols(ref golsJogador, ref golsComputador, pontosJogador, pontosComputador);
        Console.WriteLine("Fim de jogo!");


        if (pontosJogador == pontosComputador)
    {
        if (energiaJogador > energiaComputador)
        {
            Console.WriteLine($"                                                {jogador.Nome} venceu por ter mais energias!");


        Console.WriteLine("                                                     ------------------------------------------");
        Console.WriteLine("                                                                 '._==_==_=_.'");
        Console.WriteLine("                                                                 .-\\:      /-.");
        Console.WriteLine("                                                                | (|:.     |) |");
        Console.WriteLine("                                                                 '-|:.     |-'");
        Console.WriteLine("                                                                   \\::.    /");
        Console.WriteLine("                                                                    '::. .'");
        Console.WriteLine("                                                                      ) (");
        Console.WriteLine("                                                                    _.' '._");
        Console.WriteLine("                                                     ------------------------------------------");
        Environment.Exit(0);

        }
        else if (energiaComputador > energiaJogador)
        {
            Console.WriteLine("                                                 Computador venceu por ter mais energias!");

        Console.WriteLine("                                                     ------------------------------------------");
        Console.WriteLine("                                                                 '._==_==_=_.'");
        Console.WriteLine("                                                                 .-\\:      /-.");
        Console.WriteLine("                                                                | (|:.     |) |");
        Console.WriteLine("                                                                 '-|:.     |-'");
        Console.WriteLine("                                                                   \\::.    /");
        Console.WriteLine("                                                                    '::. .'");
        Console.WriteLine("                                                                      ) (");
        Console.WriteLine("                                                                    _.' '._");
        Console.WriteLine("                                                     ------------------------------------------");
        Environment.Exit(0);





        }
    
    }
    else
    {
        Console.WriteLine("Fim de jogo!");
    }


    
    }


































//EXIBIR RESULTADO DE AMBOS JOGADORES]


   private void ExibirResultado(string nomeJogador1, string nomeJogador2, int golsJogador1, int golsJogador2, int pontosJogador, int pontosComputador, int energiaJogador, int energiaComputador)
    {
        Console.ReadLine();
        LimparTela();

        if (resp == 0){
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"------------------------------------------------------------------ Resultado {jogador.Nome} x Computador ------------------------------------------------------------------");

        
        Console.WriteLine("                                                                            '._==_==_=_.'");
        Console.WriteLine("                                                                            .-\\:      /-.");
        Console.WriteLine("                                                                           | (|:.     |) |");
        Console.WriteLine("                                                                            '-|:.     |-'");
        Console.WriteLine("                                                                              \\::.    /");
        Console.WriteLine("                                                                               '::. .'");
        Console.WriteLine("                                                                                 ) (");
        Console.WriteLine("                                                                               _.' '._");



        Console.ResetColor();
        Console.WriteLine($"Pontos de {nomeJogador1}: {pontosJogador} | Energias: {energiaJogador}");
        Console.WriteLine($"Pontos de {nomeJogador2}: {pontosComputador} | Energias: {energiaComputador}");
        Console.WriteLine($"GOLS de {nomeJogador1}: {golsJogador1}");
        Console.WriteLine($"GOLS de {nomeJogador2}: {golsJogador2}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        Console.ResetColor();
        }
        
        else if (resp == 1){
   
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"------------------------------------------------------------------ Resultado {jogador.Nome} x {jogador2.Nome} ----------------------------------------------------------------");



        Console.WriteLine("                                                                                 '._==_==_=_.'");
        Console.WriteLine("                                                                                 .-\\:      /-.");
        Console.WriteLine("                                                                                | (|:.     |) |");
        Console.WriteLine("                                                                                 '-|:.     |-'");
        Console.WriteLine("                                                                                   \\::.    /");
        Console.WriteLine("                                                                                    '::. .'");
        Console.WriteLine("                                                                                      ) (");
        Console.WriteLine("                                                                                    _.' '._");






        Console.ResetColor();
        Console.WriteLine($"                                                            Pontos de {jogador.Nome}: {pontosJogador} | Energias: {energiaJogador}");
        Console.WriteLine($"                                                            Pontos de {jogador2.Nome}: {pontosComputador} | Energias: {energiaComputador}");
        Console.WriteLine($"                                                            GOLS de {jogador.Nome}: {golsJogador1}");
        Console.WriteLine($"                                                            GOLS de {jogador2.Nome}: {golsJogador2}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        Console.ResetColor();


         if (resp == 1 && golsJogador1 > golsJogador2 && pontosJogador>pontosComputador || golsJogador1 > golsJogador2 && pontosJogador<pontosComputador || golsJogador1 == golsJogador2 && pontosJogador>pontosComputador )
        {
            Console.WriteLine($"PARABÉNS, {jogador.Nome}! VOCÊ VENCEU A PARTIDA");
            Console.WriteLine($"{jogador.Nome}: {pontosJogador} pontos.");
            LimparTela();

        }
        else if (resp == 1 && golsJogador2 > golsJogador1 && pontosComputador>pontosJogador || golsJogador2 > golsJogador1 && pontosComputador<pontosJogador ||golsJogador2 == golsJogador1 && pontosComputador>pontosJogador  )
        {
            Console.WriteLine($"{jogador2.Nome} VENCEU VOCÊ VENCEU A PARTIDA");
            
            LimparTela();
        }

     else if (resp == 1 && golsJogador == golsJogador2 && pontosComputador == pontosJogador)
        {
            Console.WriteLine("O JOGO TERMINOU EMPATADO!");
            Console.WriteLine("Escolha o que deseja fazer para desempatar:");
            Console.WriteLine("1. Disputa de pênaltis");
            Console.WriteLine("2. Gol de ouro");
            Console.WriteLine("3. Permanecer empatado");
            Console.WriteLine("4. Prorrogação");
            Console.WriteLine("Insira a opção nos números do teclado");
       

           opcaoDesempate = int.Parse(Console.ReadLine());

            switch (opcaoDesempate)
            {
                case 1:
                    DisputaPenaltis();
                    break;
                case 2:
                    GolDeOuro();
                    break;
            
                case 3:
                    Console.WriteLine("O jogo permanece empatado.");
                    break;


                case 4:
                    Prorrogacao();
                    break;


                default:
                    Console.WriteLine("Opção inválida. O jogo permanece empatado.");
                    break;
            }
        }


        }

        
        
        if (resp == 1 &&  golsJogador1 > golsJogador2 && pontosJogador>pontosComputador || golsJogador1 > golsJogador2 && pontosJogador<pontosComputador || golsJogador1 == golsJogador2 && pontosJogador>pontosComputador )
        {
            Console.WriteLine($"PARABÉNS, {nomeJogador1}! VOCÊ VENCEU A PARTIDA");
            


        Console.ForegroundColor = ConsoleColor.Yellow;    
        Console.WriteLine("            '._==_==_=_.'");
        Console.WriteLine("            .-\\:      /-.");
        Console.WriteLine("           | (|:.     |) |");
        Console.WriteLine("            '-|:.     |-'");
        Console.WriteLine("              \\::.    /");
        Console.WriteLine("               '::. .'");
        Console.WriteLine("                 ) (");
        Console.WriteLine("               _.' '._");
        Console.ResetColor();



        }
        else if (resp == 0 && golsJogador2 > golsJogador1 && pontosComputador>pontosJogador || golsJogador2 > golsJogador1 && pontosComputador<pontosJogador ||golsJogador2 == golsJogador1 && pontosComputador>pontosJogador  )
        {
            Console.WriteLine($"{nomeJogador2} VENCEU A PARTIDA");
            


        Console.ForegroundColor = ConsoleColor.Yellow;    
        Console.WriteLine("            '._==_==_=_.'");
        Console.WriteLine("            .-\\:      /-.");
        Console.WriteLine("           | (|:.     |) |");
        Console.WriteLine("            '-|:.     |-'");
        Console.WriteLine("              \\::.    /");
        Console.WriteLine("               '::. .'");
        Console.WriteLine("                 ) (");
        Console.WriteLine("               _.' '._");
        Console.ResetColor();



        }
        else if (resp == 0 && golsJogador == golsJogador2 && pontosComputador == pontosJogador)
        {
            Console.WriteLine("O JOGO TERMINOU EMPATADO!");
            Console.WriteLine("Escolha o que deseja fazer para desempatar:");
            Console.WriteLine("1. Disputa de pênaltis");
            Console.WriteLine("2. Gol de ouro");
            Console.WriteLine("3. Permanecer empatado");
            Console.WriteLine("4. Prorrogação");
            Console.WriteLine("Insira a opção nos números do teclado");

           opcaoDesempate = int.Parse(Console.ReadLine());

            switch (opcaoDesempate)
            {
                case 1:
                    DisputaPenaltis();
                    break;
                case 2:
                    GolDeOuro();
                    break;
            
                case 3:
                    Console.WriteLine("O jogo permanece empatado.");
                    break;


                case 4:
                    Prorrogacao();
                    break;


                default:
                    Console.WriteLine("Opção inválida. O jogo permanece empatado.");
                    break;
            }
        }
    }
































private void Prorrogacao()
{


    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");


    
    

    if (resp == 0)
    {

            

            Console.WriteLine("Iniciando prorrogação...");

            // Lógica da prorrogação
            int[] cartasJogador1 = { 1, 2, 3 };
            int[] cartasJogador2 = { 1, 2, 3 };

            int energiaJogador1 = 0;
            int energiaJogador2 = 0;

            // Crie uma instância da classe JogoFutebol
        

            int pontosJogador1 = CalcularPontosPRO(cartasJogador1, "Jogador", ref energiaJogador1);
            int pontosJogador2 = CalcularPontosPRO(cartasJogador2, "Computador", ref energiaJogador2);

            // Exibindo resultado da prorrogação
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");



            if (pontosJogador1 > pontosJogador2)
            {   
                LimparTela();
                Console.ForegroundColor = ConsoleColor.Yellow;    
                Console.WriteLine($"------------------------------Resultado da prorrogação-------------------------------------- ");
                Console.ResetColor();
                Console.WriteLine($"                    {jogador.Nome} | Computador                  ");
                Console.WriteLine($"                   {pontosJogador1} x {pontosJogador2}                  ");
                Console.ForegroundColor = ConsoleColor.Yellow;    
                Console.WriteLine("----------------------------------------------------------------------------------------------");    
                Console.ResetColor();        
                
                

               
     

        Console.ForegroundColor = ConsoleColor.Yellow;    
        Console.WriteLine("                                         '._==_==_=_.'");
        Console.WriteLine("                                         .-\\:      /-.");
        Console.WriteLine("                                        | (|:.     |) |");
        Console.WriteLine("                                         '-|:.     |-'");
        Console.WriteLine("                                           \\::.    /");
        Console.WriteLine("                                            '::. .'");
        Console.WriteLine("                                              ) (");
        Console.WriteLine("                                            _.' '._");
        Console.ResetColor();
        Console.WriteLine($"                    PARABÉNS !!! {jogador.Nome} Venceu a prorrogação");            





            }
            else if (pontosJogador2 > pontosJogador1)
            { 
             


                Console.ForegroundColor = ConsoleColor.Yellow;    
                Console.WriteLine($"------------------------------Resultado da prorrogação-------------------------------------- ");
                Console.ResetColor();
                Console.WriteLine($"                        {jogador.Nome} | Computador                  ");
                Console.WriteLine($"                        {pontosJogador1}  x {pontosJogador2} ");
                Console.ForegroundColor = ConsoleColor.Yellow;    
                Console.WriteLine("----------------------------------------------------------------------------------------------");    
                Console.ResetColor();   
                



     
        Console.ForegroundColor = ConsoleColor.Yellow;    
        Console.WriteLine("                                         '._==_==_=_.'");
        Console.WriteLine("                                         .-\\:      /-.");
        Console.WriteLine("                                        | (|:.     |) |");
        Console.WriteLine("                                         '-|:.     |-'");
        Console.WriteLine("                                           \\::.    /");
        Console.WriteLine("                                            '::. .'");
        Console.WriteLine("                                              ) (");
        Console.WriteLine("                                            _.' '._");
        Console.ResetColor();
        Console.WriteLine($"                            Computador Venceu a prorrogação"); 





            }

              if (pontosJogador1 == pontosJogador2 ){

            // Determinando o vencedor
            DeterminarVencedor(pontosJogador1, pontosJogador2, resp);
            }
      
    }
    else if (resp == 1)
    {



            Console.WriteLine("Iniciando prorrogação...");

            // Lógica da prorrogação
            int[] cartasJogador1 = { 1, 2, 3 };
            int[] cartasJogador2 = { 1, 2, 3 };

            int energiaJogador1 = 0;
            int energiaJogador2 = 0;

        

            // Crie uma instância da classe JogoFutebol
           

            int pontosJogador1 = CalcularPontosPRO(cartasJogador1, "Jogador 1", ref energiaJogador1);
            int pontosJogador2 = CalcularPontosPRO(cartasJogador2, "Jogador 2", ref energiaJogador2);

            if (pontosJogador1 > pontosJogador2)
            { 
       

                          Console.ForegroundColor = ConsoleColor.Yellow;    
                Console.WriteLine($"------------------------------Resultado da prorrogação-------------------------------------- ");
                Console.ResetColor();
                Console.WriteLine($"                        {jogador.Nome} | {jogador2.Nome}                 ");
                Console.WriteLine($"                        {pontosJogador1}  x {pontosJogador2} ");
                Console.ForegroundColor = ConsoleColor.Yellow;    
                Console.WriteLine("----------------------------------------------------------------------------------------------");     
                Console.ResetColor();        
                


        Console.ForegroundColor = ConsoleColor.Yellow;    
        Console.WriteLine("                                         '._==_==_=_.'");
        Console.WriteLine("                                         .-\\:      /-.");
        Console.WriteLine("                                        | (|:.     |) |");
        Console.WriteLine("                                         '-|:.     |-'");
        Console.WriteLine("                                           \\::.    /");
        Console.WriteLine("                                            '::. .'");
        Console.WriteLine("                                              ) (");
        Console.WriteLine("                                            _.' '._");
        Console.ResetColor();
        Console.WriteLine($"PARABÉNS !!! {jogador.Nome} Venceu a prorrogação");



            }
            else if (pontosJogador2 > pontosJogador1)
            { 
            

                Console.ForegroundColor = ConsoleColor.Yellow;    
                Console.WriteLine($"------------------------------Resultado da prorrogação-------------------------------------- ");
                Console.ResetColor();
                Console.WriteLine($"{jogador.Nome} - {pontosJogador1} Gols x {jogador2.Nome} - {pontosJogador2} Gols");
                Console.ForegroundColor = ConsoleColor.Yellow;    
                Console.WriteLine("----------------------------------------------------------------------------------------------");      
                Console.ResetColor();     
                

                Console.ForegroundColor = ConsoleColor.Yellow;    
                Console.WriteLine("                                         '._==_==_=_.'");
                Console.WriteLine("                                         .-\\:      /-.");
                Console.WriteLine("                                        | (|:.     |) |");
                Console.WriteLine("                                         '-|:.     |-'");
                Console.WriteLine("                                           \\::.    /");
                Console.WriteLine("                                            '::. .'");
                Console.WriteLine("                                              ) (");
                Console.WriteLine("                                            _.' '._");
                Console.ResetColor();
                Console.WriteLine($"{jogador2.Nome}  Venceu a prorrogação");  

            }

            if (pontosJogador1 == pontosJogador2 ){

            // Determinando o vencedor
            DeterminarVencedor(pontosJogador1, pontosJogador2, resp);
            }
    }
}





























//DETERMINAR VENCEDOR DA PRORROGAÇÃO


private static void DeterminarVencedor(int pontosJogador1, int pontosJogador2, int resp)
{
    // Lógica para determinar o vencedor após a prorrogação
    if (pontosJogador1 > pontosJogador2)
    {
        Console.WriteLine($"Jogador {(resp == 0 ? "" : "1")} é o vencedor da prorrogação!");
    }
    else if (pontosJogador2 > pontosJogador1)
    {
        Console.WriteLine($"Jogador {(resp == 0 ? "Computador" : "2")} é o vencedor da prorrogação!");
    }
    else
    {
        Console.WriteLine("A prorrogação terminou em empate. Vai para a disputa de pênaltis ou outro critério de desempate.");

        if (resp == 0)
        {
            Console.WriteLine("Iniciando a disputa de pênaltis...");

            int pontosJogador1Penaltis = 0;
            int pontosJogador2Penaltis = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Pênalti {i + 1}: Escolha o canto (1 - Esquerda, 2 - Centro, 3 - Direita) - Jogador");
                int escolhaJogador = int.Parse(Console.ReadLine());

                Random random = new Random();
                int escolhaComputador = random.Next(1, 4);

                if (escolhaJogador == escolhaComputador)
                {
                    Console.WriteLine("Jogador marcou o pênalti!");
                    pontosJogador1Penaltis++;
                }
                else
                {
                    Console.WriteLine("Jogador errou o pênalti!");
                }

                Console.WriteLine($"Pênalti {i + 1}: Escolha o canto (1 - Esquerda, 2 - Centro, 3 - Direita) - Computador");
                int escolhaComputadorPenaltis = random.Next(1, 4);

                if (escolhaComputadorPenaltis == escolhaJogador)
                {
                    Console.WriteLine("Computador marcou o pênalti!");
                    pontosJogador2Penaltis++;
                }
                else
                {
                    Console.WriteLine("Computador errou o pênalti!");
                }
            }

            Console.WriteLine("---------------- Resultado Pênaltis -----------------");
            Console.WriteLine($"Jogador 1: {pontosJogador1Penaltis} x {pontosJogador2Penaltis} :Computador");

            if (pontosJogador1Penaltis > pontosJogador2Penaltis)
            {
                Console.WriteLine($"PARABÉNS, Jogador! Você venceu na disputa de pênaltis.");

        Console.ForegroundColor = ConsoleColor.Yellow;    
        Console.WriteLine("            '._==_==_=_.'");
        Console.WriteLine("            .-\\:      /-.");
        Console.WriteLine("           | (|:.     |) |");
        Console.WriteLine("            '-|:.     |-'");
        Console.WriteLine("              \\::.    /");
        Console.WriteLine("               '::. .'");
        Console.WriteLine("                 ) (");
        Console.WriteLine("               _.' '._");
        Console.ResetColor();




            }
            else if (pontosJogador2Penaltis > pontosJogador1Penaltis)
            {
                Console.WriteLine($"PARABÉNS, Computador! Você venceu na disputa de pênaltis.");


        Console.ForegroundColor = ConsoleColor.Yellow;    
        Console.WriteLine("            '._==_==_=_.'");
        Console.WriteLine("            .-\\:      /-.");
        Console.WriteLine("           | (|:.     |) |");
        Console.WriteLine("            '-|:.     |-'");
        Console.WriteLine("              \\::.    /");
        Console.WriteLine("               '::. .'");
        Console.WriteLine("                 ) (");
        Console.WriteLine("               _.' '._");
        Console.ResetColor();
       




            }
        }else if (resp == 1){ 

            


        }
    }
}



























//CALCULAR PONTOS DA PRORROGAÇÃO
private static int CalcularPontosPRO(int[] cartasJogador, string jogadorNome, ref int energia, bool aguardarInput = true)
{
    Console.Clear();

  
    int pontosRodada = 0;
    int golsRodada = 0;

    Random random = new Random();

    for (int i = 0; i < cartasJogador.Length; i++)
    {
        int cartaSelecionada = random.Next(1, 6);

        Console.WriteLine($"Carta {i + 1}: {cartaSelecionada}");

        switch (cartaSelecionada)
        {
            case 1:
                Console.WriteLine("GOL - 3 pontos");
                pontosRodada += 3;
                golsRodada++;
                break;
            case 2:
                Console.WriteLine("Pênalti - 2 pontos");

                if (aguardarInput)
                {
                    Console.WriteLine("PENALTI!!!! ESCOLHA O CANTO PARA BATER. (1-ESQUERDA 2-CENTRO 3-DIREITO) - " + jogadorNome);
                    int respPenalti = int.Parse(Console.ReadLine());

                    int penalti = random.Next(1, 4);

                    if (respPenalti == penalti)
                    {
                        Console.WriteLine("GOL!!!! Você ganhou 2 pontos");
                        pontosRodada += 2;
                        golsRodada++;
                    }
                    else
                    {
                        Console.WriteLine("ERROU!");
                    }
                }
                else
                {
                    int penalti = random.Next(1, 4);

                    if (penalti == 1)
                    {
                        Console.WriteLine("GOL!!!! O computador marcou 2 pontos");
                        pontosRodada += 2;
                        golsRodada++;
                    }
                    else
                    {
                        Console.WriteLine("ERROU! O computador perdeu a chance.");
                    }
                }
                break;
            case 3:
                Console.WriteLine("Falta - 1 ponto");
                pontosRodada += 1;
                break;
            case 4:
                Console.WriteLine("Cartão Amarelo - 1 ponto");
                pontosRodada += 1;
                break;
            case 5:
                Console.WriteLine("Cartão Vermelho - 0 pontos");
                break;
            default:
                Console.WriteLine("Carta desconhecida");
                break;
        }

        if (aguardarInput)
        {
            Console.ReadLine();
        }
    }

    Console.WriteLine($"Total de pontos na rodada: {pontosRodada}");
    Console.WriteLine($"Total de gols na rodada: {golsRodada}");
    return golsRodada;
}

















//DISPUTA DE PENALTIS
  private void DisputaPenaltis()
{
    Console.WriteLine("Iniciando a disputa de pênaltis...");

    int pontosJogador1 = 0;
    int pontosJogador2 = 0;

    if (resp == 0)
    {
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine($"Pênalti {i + 1}: Escolha o canto (1 - Esquerda, 2 - Centro, 3 - Direita) - {jogador.Nome}");
            int escolhaJogador = int.Parse(Console.ReadLine());

            Random random = new Random();
            int escolhaSorte = random.Next(1, 4);

            if (escolhaJogador == escolhaSorte)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{jogador.Nome} marcou o pênalti!");
                Console.ResetColor();
                pontosJogador1++;
            }
            else
            {
                Console.WriteLine($"{jogador.Nome} errou o pênalti!");
            }



            Console.WriteLine("Computador fez a sua escolha");

            int escolhaComputador = random.Next(1, 4);

            if (escolhaComputador == escolhaSorte)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Computador marcou o pênalti!");
                Console.ResetColor();
                pontosJogador2++;
            }
            else
            {
                Console.WriteLine($"Computador errou o pênalti!");
            }
        }

            LimparTela();
    Console.WriteLine("-------------------- Resultado Pênaltis ------------------------");
    Console.WriteLine($"{jogador.Nome}: {pontosJogador1} x {pontosJogador2} : Computador");
    Console.WriteLine("-----------------------------------------------------------------");

    if (pontosJogador1 > pontosJogador2)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"PARABÉNS, {jogador.Nome}! Você venceu na disputa de pênaltis.");
        Console.ResetColor();
    }
    else if (pontosJogador2 > pontosJogador1)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"PARABÉNS, Computador! Você venceu na disputa de pênaltis.");
        Console.ResetColor();
    }
    }
    else if (resp == 1)
    {


        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Pênalti {i + 1}: Escolha o canto (1 - Esquerda, 2 - Centro, 3 - Direita) - {jogador.Nome}");
            int escolhaJogador = int.Parse(Console.ReadLine());
        

            Random random = new Random();
            int escolhaComputador = random.Next(1, 4);



            if (escolhaJogador == escolhaComputador)
            {   
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{jogador.Nome} marcou o pênalti!");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ResetColor();
                pontosJogador1++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{jogador.Nome} errou o pênalti!");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ResetColor();
            }
        }

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Pênalti {i + 1}: Escolha o canto (1 - Esquerda, 2 - Centro, 3 - Direita) - {jogador2.Nome}");
            int escolhaJogador2 = int.Parse(Console.ReadLine());

            Random random = new Random();
            int escolhaComputador = random.Next(1, 4);


            if (escolhaJogador2 == escolhaComputador)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{jogador2.Nome} marcou o pênalti!");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ResetColor();
                pontosJogador2++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{jogador2.Nome} errou o pênalti!");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ResetColor();
            }
        }
    
    LimparTela();
    Console.ForegroundColor = ConsoleColor.Yellow; 
    Console.WriteLine("-------------------- Resultado Pênaltis ------------------------");
        Console.ForegroundColor = ConsoleColor.Yellow;    
        Console.WriteLine("            '._==_==_=_.'");
        Console.WriteLine("            .-\\:      /-.");
        Console.WriteLine("           | (|:.     |) |");
        Console.WriteLine("            '-|:.     |-'");
        Console.WriteLine("              \\::.    /");
        Console.WriteLine("               '::. .'");
        Console.WriteLine("                 ) (");
        Console.WriteLine("               _.' '._");
        Console.ResetColor();
       

    Console.WriteLine($"{jogador.Nome}: {pontosJogador1} x {pontosJogador2} :{jogador2.Nome}");
    Console.WriteLine("-----------------------------------------------------------------");
    Console.ResetColor();

    if (pontosJogador1 > pontosJogador2)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"PARABÉNS, {jogador.Nome}! Você venceu na disputa de pênaltis.");
        Console.ResetColor();
    }
    else if (pontosJogador2 > pontosJogador1)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"PARABÉNS, {jogador2.Nome}! Você venceu na disputa de pênaltis.");
        Console.ResetColor();
    }
    }
}
































//G0L DE OURO



    private void GolDeOuro()
{



    Console.WriteLine("Iniciando o Gol de Ouro...");

    int golsJogador1 = 0;
    int golsJogador2 = 0;

   
        if (resp == 0)
        {

              for (int i = 0; i < 5; i++){
            Console.WriteLine($"Jogada: jogador está perto de marcar na área adversária (1 - Esquerda, 2 - Centro, 3 - Direita) - {jogador.Nome}");
            int escolhaJogador = int.Parse(Console.ReadLine());

            Random random = new Random();
            int escolhaComputador = random.Next(1, 4);

               if (escolhaJogador == escolhaComputador)
            {   
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"{jogador.Nome} marcou o gol de ouro!");
                golsJogador1++;
                break;
            }
            else
            {   
                
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"{jogador.Nome} errou o gol de ouro!");
            }


            Console.WriteLine($"O Computador escolheu o canto {escolhaComputador}");

            escolhaComputador = random.Next(1, 4);


            }

            Console.WriteLine("---------------- Resultado Gol de Ouro -----------------");
            Console.WriteLine($"{jogador.Nome}: {golsJogador1} x {golsJogador2} : Computador");

            if (golsJogador1 > golsJogador2)
            {
                Console.WriteLine($"PARABÉNS, {jogador.Nome}! Você venceu no gol de ouro.");
            }
            else if (golsJogador2 > golsJogador1)
            {
                Console.WriteLine($"PARABÉNS, Computador! Você venceu no gol de ouro.");
            }
            else
            {
                Console.WriteLine("O gol de ouro também terminou empatado. Vamos para o próximo desempate.");
                DisputaPenaltis();
            }
          }
       
        else if (resp == 1)
        {


            for (int i = 0; i < 5; i++){
            Random random = new Random();
            int VezDoJogador = random.Next(1, 2);

            if (VezDoJogador == 1)
            {
                // Jogador 1


                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                
                Console.WriteLine($"Jogada: jogador está perto de marcar na área adversária (1 - Esquerda, 2 - Centro, 3 - Direita) - {jogador.Nome}");
                int escolhaJogador = int.Parse(Console.ReadLine());

                // Jogador 2

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                        
                Console.WriteLine($"Jogada: jogador está perto de marcar na área adversária (1 - Esquerda, 2 - Centro, 3 - Direita) - {jogador2.Nome}");
                int escolhaJogador2 = int.Parse(Console.ReadLine());

                int placarOuro = random.Next(0, 3);


                }

                Console.WriteLine("---------------- Resultado Gol de Ouro -----------------");
                Console.WriteLine($"{jogador.Nome}: {golsJogador1} x {golsJogador2} : {jogador2.Nome}");

                if (golsJogador1 > golsJogador2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine($"PARABÉNS, {jogador.Nome}! Você venceu no gol de ouro.");
                }
                else if (golsJogador2 > golsJogador1)
                {

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine($"PARABÉNS, {jogador2.Nome}! Você venceu no gol de ouro.");
                }
                else
                {
                    Console.WriteLine("O gol de ouro também terminou empatado. Vamos para o próximo desempate.");
                    DisputaPenaltis();
                }
            }
            
        }
  

    
    }











//PLACAR DE PONTOS
    private void ExibirPlacar(string nomeJogador1, string nomeJogador2, int pontosJogador1, int pontosJogador2)
    {
        
        Console.WriteLine($"Placar de pontos: {nomeJogador1} ({pontosJogador1}) - {nomeJogador2} ({pontosJogador2})");
        Console.WriteLine($"Placar de gols: {nomeJogador1} ({golsJogador1}) - {nomeJogador2} ({golsComputador})");
    }












//PLACAR DE ENERGIA

    private void ExibirStatus(int energiaJogador1, string nomeJogador2, int energiaJogador2, int pontosJogador1, int pontosJogador2)
    {
        Console.WriteLine($"Energia de {jogador.Nome}: {energiaJogador1}");
        Console.WriteLine($"Energia de {nomeJogador2}: {energiaJogador2}");
        ExibirPlacar(jogador.Nome, nomeJogador2, pontosJogador1, pontosJogador2);
    }




















//Atualizar quando o jogador faz gol ou ganha pontos
private void AtualizarGols(ref int golsJogador, ref int golsComputador, int pontosJogador, int pontosComputador)
{
    Console.WriteLine($"Gols: {jogador.Nome} - {golsJogador} | Computador - {golsComputador}");

    if (golsJogador > golsComputador)
    {
        Console.WriteLine($"{jogador.Nome} venceu a partida com mais gols!");
    }
    else if (golsComputador > golsJogador)
    {
        Console.WriteLine("Computador venceu a partida com mais gols!");
    }
    else
    {
        Console.WriteLine("Número de gols igual.");

        if (pontosJogador > pontosComputador)
        {
            Console.WriteLine($"{jogador.Nome} venceu a partida com mais pontos!");
        }
        else if (pontosComputador > pontosJogador)
        {
            Console.WriteLine("Computador venceu a partida com mais pontos!");
        }
        else
        {
            Console.WriteLine("A partida terminou em empate.");
        }
    }
}










//GERAR CARTAS ALEATÓRIAS PARA O JOGADOR QUE FOR ABRIR
private int[] GerarCartasAleatorias(Random random)
{
    int[] cartas = new int[3];
    int chanceCartaIgual = random.Next(1, 8);  

    for (int i = 0; i < cartas.Length; i++)
    {
        if (random.Next(1, 7) <= chanceCartaIgual)  
        {
            cartas[i] = random.Next(1, 7);
        }
        else
        {
            cartas[i] = random.Next(1, 6);
        }
    }

    return cartas;
}








//CALCULAR OS PONTOS CASO AS CARTAS FOREM IGUAIS corrijido***

    private int CalcularPontos(int[] cartasJogador, string jogadorNome, ref int energia)
    {
       
  int cartasIguais = 0;

       if (jogadorNome == "Computador")
{
    LimparTela();
    Console.WriteLine($"{jogadorNome} jogando");

  

    for (int i = 0; i < cartasJogador.Length; i++)
    {
        Console.WriteLine($"Carta {i + 1}: {cartasJogador[i]}");

         if (cartasJogador[i] == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Gol");
            Console.ResetColor();
        }
        else if (cartasJogador[i] == 2)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pênalti");
            Console.ResetColor();
        }
        else if (cartasJogador[i] == 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Falta");
            Console.ResetColor();
            
        }
        else if (cartasJogador[i] == 4)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cartão amarelo");
            Console.ResetColor();
        }
        else if (cartasJogador[i] == 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cartão vermelho");
            Console.ResetColor();
        }
        else if (cartasJogador[i] == 6)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Energia");
            Console.ResetColor();
        }

        if (i > 0 && cartasJogador[i] == cartasJogador[i - 1])
        {
            cartasIguais++;
        }
     
    }
       Console.ReadLine();
}
else
{


    
    Console.ReadLine();

    for (int i = 0; i < cartasJogador.Length; i++)
    {
        Console.WriteLine($"Carta {i + 1}: {cartasJogador[i]}");

       if (cartasJogador[i] == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Gol");
            Console.ResetColor();
        }
        else if (cartasJogador[i] == 2)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pênalti");
            Console.ResetColor();
        }
        else if (cartasJogador[i] == 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Falta");
            Console.ResetColor();
            
        }
        else if (cartasJogador[i] == 4)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cartão amarelo");
            Console.ResetColor();
        }
        else if (cartasJogador[i] == 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cartão vermelho");
            Console.ResetColor();
        }
        else if (cartasJogador[i] == 6)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Energia");
            Console.ResetColor();
        }

        if (i > 0 && cartasJogador[i] == cartasJogador[i - 1])
        {
            cartasIguais++;
        }

        Console.ReadLine();
    }
}


        //CASO AS CARTAS FOREM IGUAIS

        if (cartasIguais == 2) 
        {
            int valorCartaRepetida = cartasJogador[0]; 

            switch (valorCartaRepetida)
            {
                case 1:
                    Console.WriteLine("GOL ");

                    if(jogadorNome == "Computador"){
                    golsComputador++;

                    }else if (jogadorNome == jogador2.Nome){
                        
                        golsJogador2++;
                    }else if (jogadorNome == jogador.Nome){
                        golsJogador1++;
                    }


                    
                    return 3;
                case 2:
                    

                     Console.WriteLine("PENALTI!!!! ESCOLHA O CANTO PARA BATER. (1-ESQUERDA 2-CENTRO 3-DIREITO) - " + jogadorNome);
                      int respPenalti = int.Parse(Console.ReadLine());

                 Random random = new Random();
                 int penalti = random.Next(1, 4);

                  if (respPenalti == penalti)
                    {
                     Console.WriteLine("GOL!!!!");

                         if(jogadorNome == "Computador"){
                    golsComputador++;

                    }else if (jogadorNome == jogador2.Nome){
                        
                        golsJogador2++;
                    }else if (jogadorNome == jogador.Nome){
                        golsJogador1++;
                    }




                 return 2;
                
                 }
                else
                {
                Console.WriteLine("ERROU!");
                return 0;
                }

                 
                case 3:
                    Console.WriteLine("Falta - 1 ponto");
                    return 1;
                case 4:
                    Console.WriteLine("Cartão Amarelo - 1 ponto");
                    energia = energia - 1;
                    return 1;
                case 5:
                    Console.WriteLine("Cartão Vermelho - 0 pontos");
                    energia = energia -2;
                    return 0;
                case 6:
                    Console.WriteLine("Energia - 2 energias");
                    energia = energia + 2;
                    return 2;
                default:
                    Console.WriteLine("Carta desconhecida");
                    return 0;
            }
        }
        else
        {
            Console.WriteLine("Cartas diferentes, nenhum ponto é repassado");
            return 0;
        }

    }

    








}

class Jogador
{
    public string Nome { get; set; }
}

class Computador
{
    public string Nome { get; set; } = "Computador";
    public int Energia { get; set; } = 10;
}




