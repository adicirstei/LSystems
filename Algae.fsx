#load "LSystem.fsx"
    
let algae:LSystem.LSystem = {
    axiom = ['A']
    rules = Map.ofList ['A', ['A'; 'B']
                        'B', ['A']]
}

LSystem.evolveTo algae 4