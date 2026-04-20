# Sistema de Autonomia de Veículos - C# .NET 8

Sistema de cadastro e cálculo de autonomia de veículos, desenvolvido para demonstrar conceitos de **Orientação a Objetos** em C#.

## Conceitos aplicados

| Conceito | Onde é usado |
|---|---|
| **Herança** | `Carro`, `Moto` e `Caminhao` herdam de `Veiculo` |
| **Polimorfismo** | `CalcularAutonomia()` e `ExibirDados()` sobrescritos em cada subclasse |
| **Enum** | `TipoVeiculo` garante tipos válidos sem erros de digitação |
| **LINQ** | Usado em estatísticas: `Max()`, `Min()`, `Average()`, `OrderBy()`, `Count()` |
| **Encapsulamento** | Propriedades com getters/setters, validação de entrada em `LerDouble()` |

## Funcionalidades

- Cadastro dinâmico de veículos (sem limite fixo)
- Três tipos de veículos com regras próprias de autonomia:
  - **Carro** — +5% de eficiência
  - **Moto** — +12% de eficiência
  - **Caminhão** — -10% base + redução proporcional à carga transportada
- Listagem detalhada com autonomia final calculada
- Estatísticas gerais (maior, menor e média de autonomia)
- Comparação direta entre dois veículos cadastrados

## Como executar

```bash
dotnet run
```

## Menu do programa

```
[1] Cadastrar veiculo
[2] Listar todos
[3] Estatisticas gerais
[4] Comparar dois veiculos
[0] Sair
```

## Estrutura do projeto

```
MediaPorLitro/
├── TipoVeiculo.cs        # Enum com os tipos de veículo
├── Veiculo.cs            # Classe base
├── Carro.cs              # Herda de Veiculo (+5%)
├── Moto.cs               # Herda de Veiculo (+12%)
├── Caminhao.cs           # Herda de Veiculo (carga reduz autonomia)
├── Program.cs            # Menu principal e lógica do sistema
└── MediaPorLitro.csproj
```

## Tecnologias

- C# 12
- .NET 8
- IDE: JetBrains Rider

---

*Projeto desenvolvido durante o curso Técnico em Desenvolvimento de Sistemas — SENAI-MG*
