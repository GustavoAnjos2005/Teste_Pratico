// Cálculo da eficiência
function CalculateAccuracy(sample: number[]): number {
    const grade = sample.reduce((acc, val) => acc + val, 0) / sample.length;
    const AboveGrade = sample.filter(x => x > grade).length;
    return (AboveGrade / sample.length) * 100;
}

// Todas as amostras disponíveis
const samples: number[][] = [
    [50, 50, 70, 80, 100],
    [100, 95, 90, 80, 70, 60, 50],
    [70, 90, 80],
    [70, 90, 81],
    [100, 99, 98, 97, 96, 95, 94, 93, 91]
];

// Escolha da amostra
function ChooseSample(): void {
    console.log("Escolha uma das amostras:");
    samples.forEach((sample, index) => {
        console.log(`${index + 1}: ${sample.join(", ")}`);
    });

    // Função de ler a entrada do usuário e de interação
    const readline = require('readline').createInterface({
        input: process.stdin,
        output: process.stdout
    });

    const promptUser = (): void => {
        // Leitura do usuário e retorno do resultado da eficiência
        readline.question("Digite o número da amostra para ver a eficiência: ", (numero: string) => {
            const index = parseInt(numero) - 1;
            if (index >= 0 && index < samples.length) {
                const accuracy = CalculateAccuracy(samples[index]);
                console.log(`Eficiência da amostra escolhida: ${accuracy.toFixed(3)}%`);
                readline.close();
            } else {
                console.log("Número inválido. Por favor, digite o número novamente!");
                promptUser();  // Repetir a pergunta
            }
        });
    };

    promptUser();
}

ChooseSample();
