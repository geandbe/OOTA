module GPTrader.Main

open GPTrader.Constants

// taking random samples:
// http://eyalsch.wordpress.com/2010/04/01/random-sample/
// Random shuffle of an array:
// http://lorgonblog.wordpress.com/2008/03/05/play-ball-in-f/

// Training phase:
// Populate generation zero
// while (not terminate condition) do
//      foreach moment of training period
//          foreach individual in populatiom
//              perform trading step
//          end foreach
//      end foreach                                                           |
//      populate next generation ---------------------------------------------|
//      check terminate condition                                             |
// endwhile
//------------------------------------------------
// Test phase
// Pick the best organism
// Populate indicator values based on best organosm codons
// foreach moment of test period
//      do trading 
// end foreach
// report results

let populateGen0() =
    printfn "Populating Generation 0..."
    ()


[<EntryPoint>]
let main argv =
    printfn "* * *  O O T A  Genetic Trader * * *\n\n"
    printfn "Run parameters:"
    printfn "\tPopulation: %d" POPULATION_SIZE

    populateGen0()

    0 // return an integer exit code
