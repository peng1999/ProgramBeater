module Generator

let Codevs1082 (ran : System.Random)=
    let maxLength = 20//200000
    let maxOperation = 20//200000
    let maxNum = 200000

    let length = ran.Next(maxLength / 2, maxLength)
    let array = Seq.init length (fun _ -> ran.Next maxNum)

    let genOperation _ =
        match ran.Next(1, 3) with
        | 2 -> // sum
            let first = ran.Next(1, length)
            [2; first; ran.Next(first, length)]
        | _ -> // modify
            let first = ran.Next(1, length)
            [1; first; ran.Next(first, length); ran.Next maxNum]
            
    let operationLength = ran.Next(maxOperation / 2, maxOperation)
    let operations =
        Seq.init operationLength genOperation
    seq { 
        yield string length
        yield "\n"
        yield! Seq.map string array
        yield "\n"
        yield string operationLength
        yield "\n"
        let ops = operations |> Seq.map (List.map string >> String.concat " ")
        yield String.concat "\n" ops
    }
    |> String.concat " "

