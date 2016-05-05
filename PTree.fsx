#load "LSystem.fsx"
#load "Drawing.fsx"

let ptree:LSystem.LSystem = {
    axiom = ['0']
    rules = Map.ofList ['1', ['1'; '1']
                        '0', ['1'; '['; '0'; ']'; '0' ]]
}

open Drawing

let render (state: LSystem.State) : Line list =
    []


LSystem.evolveTo ptree 4
