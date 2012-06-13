module GPTrader.Main

//open GPTrader.Constants

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    printfn "%A" Constants.POPULATION_SIZE

    0 // return an integer exit code
