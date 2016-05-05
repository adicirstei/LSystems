#load "LSystem.fsx"

let ptree:LSystem.LSystem = {
    axiom = ['0']
    rules = Map.ofList ['1', ['1'; '1']
                        '0', ['1'; '['; '0'; ']'; '0' ]]
}

LSystem.evolveTo ptree 4
