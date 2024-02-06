﻿Menu();

static void Menu()
{
    Console.Clear();

    Console.WriteLine("S - Segundo");
    Console.WriteLine("M - Minuto");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Quanto tempo deseja contar? ");
}

/// <summary>
/// Inicia um contador.
/// </summary>
static void IniciarContador(int tempo)
{
    int tempoAtual = 0;

    while (tempoAtual != tempo)
    {
        Console.Clear();

        tempoAtual++;
        Console.WriteLine("Tempo atual: " + tempoAtual);

        Thread.Sleep(1000); // Aguarda 1 segundo
    }

    Console.Clear();
    Console.WriteLine("Contador finalizado!");
    Thread.Sleep(2000); // Aguarda 2 segundos
}