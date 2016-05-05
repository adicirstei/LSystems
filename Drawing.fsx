type Position = float*float

type Rotation = float

type Length = float

type Stack = (Position*Rotation) list

let push (x:(Position*Rotation)) (stack:Stack) : Stack =
    x::stack

let pop ((hd::tl):Stack) : (Position*Rotation)*Stack =
    hd,tl


let calcEndPos (x,y) rotation length =
    let endX = x + (length * cos rotation)
    let endY = y + (length * sin rotation)
    endX, endY


//open System.Drawing
//
//let i = new Bitmap(300,300)
//let g = Graphics.FromImage i
//
//let br = new SolidBrush(Color.IndianRed)
//
//g.FillRectangle(br, 0,0,300,300)
//g.Flush()
//
//i.Save "x.png"
