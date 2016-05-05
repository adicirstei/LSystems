type Symbol = char
type State = Symbol list
type Rules = Map<Symbol,State>
type LSystem = {
    axiom : State
    rules : Rules
}


let evolve (rules:Rules) (state:State) : State =
    state
    |> List.map (fun s -> defaultArg (Map.tryFind s rules) [s])
    |> List.concat

let evolveTo (ls:LSystem) (gen:int) : State =
    let rec loop n state =
        if n>= gen then state
        else evolve ls.rules state |> loop (n+1)
    loop 0 ls.axiom
