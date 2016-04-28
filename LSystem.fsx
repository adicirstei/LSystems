type Symbol = char
type State = Symbol list
type Rules = Map<Symbol,State>
type LSystem = {
    axiom : State
    rules : Rules
}
    
type Position = float*float    
    
type Rotation = float

type Length = float

type Stack = (Position*Rotation) list   
    
let evolve (rules:Rules) (state:State) : State =
    state
    |> List.map (fun s -> defaultArg (Map.tryFind s rules) [s]) 
    |> List.concat
    
let evolveTo (ls:LSystem) (gen:int) : State =
    let rec loop n state =
        if n>= gen then state
        else evolve ls.rules state |> loop (n+1)
    loop 0 ls.axiom
    
    
let push (x:(Position*Rotation)) (stack:Stack) : Stack =
    x::stack
    
let pop ((hd::tl):Stack) : (Position*Rotation)*Stack =
    hd,tl
    
    
let calcEndPos (x,y) rotation length =
    let endX = x + (length * cos rotation) 
    let endY = y + (length * sin rotation)
    endX, endY