# Repositório criado para desenvolver o case técnico para vaga de Analista de Engenharia PL na comunidade Investment Services

O desafio consiste em corrigir os seguintes problemas no codigo:
## 1. **Aplicação só está processando o primeiro item da fila infinitamente.**
> **Solução:**
- Alterar o código:
```
    while (filaOperacoes.Count >= 0)
    {
        Operacoes operacao = filaOperacoes.Peek();
```
- Para:
```
    while (filaOperacoes.Count > 0)
    {
        Operacoes operacao = filaOperacoes.Dequeue();
```    
## 2. **Implemente a funcionalidade de divisão**.
> **Solução:**
- Adicionar mais um case no switch da **Calculadora.cs**
```
    case '/': operacao.resultado = divisao(operacao); break;
```
- Implementar nova função na **Calculadora.cs**: 
```
    public int divisao(Operacoes operacao)
    {
        return operacao.valorA / operacao.valorB;
    }
```
## 3. Aplicação não está calculando a penultima operação corretamente.
> **Solução:**
- Alterar o código:
```
    public int soma(Operacoes operacao)
    {
        return operacao.valorA + operacao.valorB;
    }
```
- Para:
```
    public long soma(Operacoes operacao)
    {
        return (long)operacao.valorA + (long)operacao.valorB;
    }
```
## 4. Implemente uma funcionalidade para imprimir toda a lista de operaçõoes a ser processada após cada calculo realizado.
> **Solução:**
- Implementar o seguinte código dentro do **while filaOperacoes.Count > 0** após realizar a operação no **Program.cs**: 
```
    if (filaOperacoes.Count > 0)
    {
        foreach (Operacoes op in filaOperacoes)
        {
            Console.WriteLine("Próxima operação: {0} {1} {2}", op.valorA, op.operador, op.valorB);
        }
        Console.WriteLine("\n");
    } else
    {
        Console.WriteLine("Não restam mais operações \n");
    }
```
## 5. Crie uma nova pilha (Stack) para guardar o resultado de cada calculo efetuado e imprima a pilha ao final
> **Solução:**
- Instanciar uma **Stack** antes do **while filaOperacoes.Count > 0** no **Program.cs**:
```
    Stack resultados = new Stack();
```
- Após realizar a operação dentro do **while filaOperacoes.Count > 0**, então adicionar resultado na Stack
```
    Operacoes operacao = filaOperacoes.Dequeue();
    calculadora.calcular(operacao);
    resultados.Push(operacao.resultado);
```
- Implementar o seguinte código após a finalização do **while filaOperacoes.Count > 0** no **Program.cs**:
```
    Console.WriteLine("Imprimindo resultados das operações...");
    foreach (Object res in resultados)
    {
        Console.WriteLine(res);
    }
```
- Outras formas de imprimir a pilha mostrando o index:
```
    //Utilizando o foreach (necessário criar uma variavel de index)
    int index = resultados.Count;
    foreach (Object res in resultados)
    {
        Console.WriteLine("Resultado da {0}° operação: {1}", index, res);
        index--;
    }

    //Utilizando o for (sem a necessidade de criar uma variavel de index)
    for (int i = resultados.Count; i > 0; i--)
    {
        Console.WriteLine("Resultado da {0}° operação: {1}", i, resultados.Pop());
    }
```