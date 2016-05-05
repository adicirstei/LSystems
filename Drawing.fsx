type Position = float*float

type Rotation = float

type Length = float

type Stack = (Position*Rotation) list

type Line = { From : Position
              To : Position
            }

let push (x:(Position*Rotation)) (stack:Stack) : Stack =
    x::stack

let pop ((hd::tl):Stack) : (Position*Rotation)*Stack =
    hd,tl


let calcEndPos (x,y) rotation length =
    let endX = x + (length * cos rotation)
    let endY = y + (length * sin rotation)
    endX, endY


open System.Drawing

let DrawLine (g:Graphics) (p:Pen) line =
  g.DrawLine(p, fst line.From |> float32, snd line.From |> float32, fst line.To |> float32, snd line.To |> float32)

let draw (lines:Line seq) =
  let pen = new Pen(Color.Blue)
  let br = new SolidBrush(Color.White)

  let i = new Bitmap(600,400)
  let g = Graphics.FromImage i
  lines
  |> Seq.iter (DrawLine g pen)

  g.Flush()
  i
