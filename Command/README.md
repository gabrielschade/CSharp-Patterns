> Texto original em: https://gabrielschade.github.io/2018/04/02/gof-command.html

### Sobre o padrão Command

O padrão *Command* é relativamente simples, trata-se de criarmos uma estrutura para execução de **comandos**.

Esta estrutura é composta por:

1. Especificação do que é um comando;
2. O comando propriamente dito;
3. O executor de comandos;

Esta estrutura pode se tornar mais complexa de acordo com a necessidade, mas vamos manter as coisas simples.

O primeiro item, especificação de um comando é um item bastante abstrato. Trata-se apenas de um modelo de estrutura que todo comando deve seguir, sem nenhuma implementação real.

O comando é uma implementação que segue sua especificação, não há muito o que explicar aqui. E por fim, o executor de comandos é um mecanismo para executar todos os comandos em um determinado contexto.

Vamos para as implementações!

### Implementação utilizando Orientação à Objetos

Bom, vamos fazer as implementações seguinda a estrutura do padrão!

Primeiro começaremos com a especificação do comando, em orientação à objeto faremos isso através de uma interface!

Tudo que esta interface precisa conter é um método sem parâmetros chamado `Executar`, este é o método usado para executar o comando, como o próprio nome sugere.

```csharp
public interface IComando
{
    void Executar();
}
```

Agora, vamos criar três comandos diferentes! Dois deles serão responsáveis por logs do sistema, um por mensagem e outro por e-mail. O terceiro será um comando totalmente diferente, vamos simular que seja um comando para salvar um registro no banco de dados!

Vamos para o primeiro comando: `LogMensagemComando`. Ele terá um `field readonly` para armazenar a mensagem de log, esta mensagem deve ser informada no construtor da classe.

Não podemos esquecer de implementar a interface `IComando` e inserir o código para escrever a mensagem de log. Aqui vamos utilizar uma simples mensagem no console, afinal, a implementação do comando não faz parte do foco deste post.

```csharp
public class LogMensagemComando : IComando
{
    private readonly string _mensagem;

    public LogMensagemComando(string mensagem)
    {
        _mensagem = mensagem;
    }

    public void Executar()
    {
        Console.WriteLine($"Log: {_mensagem}");
    }
}
```
Até aqui, tudo tranquilo, certo? -Vamos continuar e criar os próximos comandos!

Podemos utilizar a mesma estrutura, alterando apenas a mensagem do executar para: "E-mail" e "Registro salvo", veja:

```csharp
public class LogEmailComando : IComando
{
    private readonly string _mensagem;
    public LogEmailComando(string mensagem)
    {
        _mensagem = mensagem;
    }

    public void Executar()
    {
        Console.WriteLine($"E-mail: {_mensagem}");
    }
}
```

Agora vamos fazer o último:

```csharp
public class SalvarRegistroComando :  IComando
{
    private readonly long _codigo;

    public SalvarRegistroComando(long codigo)
    {
        _codigo = codigo;
    }

    public void Executar()
    {
        Console.WriteLine($"Registro salvo: {_codigo}");
    }
}
```

Ótimo, temos a especificação e as implementações dos comandos! Agora só falta a implementação do executor.

Esta implementação também é bastante simples, basta criarmos uma classe para representar o executor que possua um método `Executar`. Este método deve receber uma lista de comandos e executá-los um por um.

```csharp
public class Executor
{
    public void Executar(IEnumerable<IComando> comandos)
    {
        foreach (IComando comando in comandos)
            comando.Executar();
    }
}
```
Agora já temos nossa implementação completa, vamos utilizá-la na função `Main`!

```csharp
static void Main(string[] args)
{
    ComandosOO();
    Console.ReadKey();
}

private static void ComandosOO()
{
    List<IComando> comandos = new List<IComando>();

    comandos.Add(new LogMensagemComando("Log realizado"));
    comandos.Add(new LogEmailComando("Email através de comando"));
    comandos.Add(new SalvarRegistroComando(1));
    comandos.Add(new SalvarRegistroComando(3));

    Executor executor = new Executor();
    executor.Executar(comandos);
}
```
Na nossa função `ComandosOO` criamos uma lista com todos os comandos e depois disso utilizamos um executor para efetivamente executá-los. Veja o resultado:

![Execução dos comandos - parte 1](https://i.imgur.com/nGwYDna.jpg)

Com isso finalizamos a implementação utilizando o paradigma da orientação à objetos, agora vamos para algumas reflexões.

O que mais me incomoda na implementação desta forma é que as funções dos comandos são encapsuladas em objetos que contém apenas o próprio comando. Eu não vejo nenhum tipo de vantagem na implementação ser feita desta forma, além de claro, fazê-la encaixar no modelo orientado à objetos.

Note que eu não estou dizendo em momento nenhum que isso é extrapolável para todos os padrões de projeto, mas o comando especificamente, me parece muito melhor quando implementado sob a ótica da programação funcional, portanto, vamos repensar nossa implementação em uma forma mais compacta.

### Implementação utilizando programação funcional em C#

A verdade é que não há mudanças drásticas nesta implementação, mas sim alguns detalhes que acho válido para mostrar como um segundo ponto de vista.

A primeira diferença está na ausência da especificação do comando, ela acontece sim, mas de forma muito mais transparente. Como todos os comandos são do tipo `void` e não recebem nenhum parâmetro, podemos representá-los diretamente com o delegate `Action`.

Veja como fica nossa classe `Executor` refatorada desta maneira:

```csharp
public class Executor
{
    public static void Executar(IEnumerable<Action> comandos)
    {
        foreach (Action comando in comandos)
            comando();
    }
}
```

Dessa vez não precisamos utilizar um método chamado `Executar` para cada comando, porque neste caso, a lista já é composta pelos próprios métodos, então basta executá-los.

Outro ponto que podemos alterar é a criação de cada comando individual. Como não precisamos mais fazer com que cada classe implemente a interface `IComando`, podemos agrupar os comandos em classes estáticas de acordo com seu contexto.

Primeiro vamos criar uma classe para os comandos de log, dentro dela, teremos dois métodos, um para gerar log por mensagem e outro por e-mail. Os mesmos comandos criados em classes separadas antes:

```csharp
public static class ComandosLog
{
    public static void LogPorEmail(string mensagem)
        => Console.WriteLine($"E-mail: {mensagem}");

    public static void LogPorMensagem(string mensagem)
        => Console.WriteLine($"Log: {mensagem}");
}
```
Como agora não temos mais um construtor, precisamos receber nossas mensagens por parâmetros, mas até aí, nada muito diferente do normal.

Agora, vamos criar uma classe separada para o comando que registra a gravação de um registro, afinal, são contextos muito diferentes, então convém separá-los.

```csharp
public static class ComandosSalvar
{
    public static void SalvarRegistro(long codigo)
        => Console.WriteLine($"Registro salvo: {codigo}");

}
```

Quando utilizamos o paradigma da orientação à objetos, criamos uma lista de valores do tipo `IComando` e construímos diversos objetos diferentes, um para cada comando, informando os seus respectivos parâmetros nos construtores.

Agora ao invés de criarmos um objeto para cada comando, criaremos uma função anônima. Isso é necessário porque a lista de comandos pede uma função que não recebe nenhum parâmetro e nossos comandos precisam de parâmetros para serem executados.

Ao utilizar as funções anônimas (expressões lambda) criamos uma função sem parâmetros que encapsula a chamada do comando. Na chamada do comando precisamos informar os parâmetros, mas a função que o encapsula não, portanto ela fica compatível com a lista de comandos do executor! Veja:

```csharp
private static void ComandosFP()
{
    List<Action> comandos = new List<Action>();
    comandos.Add( () => ComandosLog.LogPorMensagem("Log realizado"));
    comandos.Add( () => ComandosLog.LogPorEmail("Log realizado"));
    comandos.Add( () => ComandosSalvar.SalvarRegistro(1));
    comandos.Add( () => ComandosSalvar.SalvarRegistro(3));

    Executor.Executar(comandos);
}
```

A implementação mudou um pouco, o que acharam dos resultados?

De modo geral, eu tendo a preferir esta forma, acredito que ela seja mais simples e tenha o mesmo potêncial de utilização.

Agora, antes de fechar o post, vamos implementar este mesmo padrão, mas dessa vez com uma linguagem funcional. O F#!

### Implementação utilizando programação funcional em F#

Neste ponto você já deve estar craque sobre o que precisa ser feito, então vamos direto à pratica!
No caso do F#, também não vamos incluir uma definição abstrata do comando. Vamos utilizar o mesmo raciocínio da implementação funcional em C#, ou seja, utilizaremos diretamente as funções!

No caso do F#, por questões de código mais compacto, não é tão estranho mantermos os comandos em um único arquivo, até porque, podemos dividir o arquivo em **módulos** sem problema nenhum.

Vamos criar um módulo para os comandos de log e outro para os comandos de gravação. Dentro de cada módulo, criaremos seus respectivos comandos, veja:

```fsharp
module Comandos

module ComandosLog =
    let logPorMensagem mensagem =
        printfn "Log: %s" mensagem

    let logPorEmail mensagem =
        printfn "E-mail: %s" mensagem


module ComandosSalvar =
    let salvarRegistro codigo =
        printfn "E-mail: %i" codigo
```

No caso do F#, não é necessário criarmos a classe `Executor`, isso porque as funções podem pertencer diretamente à um módulo. Então podemos criar a função `executarComandos` por exemplo, no nível mais alto do módulo de comandos.

```fsharp
module Comandos

let executarComandos comandos = 
    comandos
    |> List.iter (fun comando -> comando() )

//... os módulos de comando estão aqui

module ComandosLog =
    let logPorMensagem mensagem =
    //... continua 
```

Com isso já temos nossa implementação pronta, basta importar os módulos com o comando `open` e utilizá-los na função `main`! 

```fsharp
let main argv =
    [
        fun () -> logPorMensagem "Log realizado"
        fun () -> logPorEmail "Log realizado"
        fun () -> salvarRegistro 1
        fun () -> salvarRegistro 3
    ]
    |> executarComandos

    Console.ReadKey() 
    |> ignore
```
Veja que a solução se torna um pouco diferente em uma linguagem voltada para o paradigma funcional, mas os conceitos são os mesmos nas três implementações!
