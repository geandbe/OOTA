module GPTrader.Quantization

/// <summary>Performs stair-step discretization of an analog value from a range into
/// a level integer value preserving units of measure. Allows for
/// direct comparison of discretized values against genotype codons</summary>
/// <typeparam name="'u">Unit of measure for this Quantizer</typeparam>
/// <param name="minVal">Low boundary of input range</param>
/// <param name="maxVal">High boundary of input range</param>
/// <param name="nSteps">Number of discretization steps;
/// should be a power of 2 in order to cover all codon values</param>
/// <returns>Quantizer instance with given parameters</returns>
/// <exception cref="System.ArgumentException">Thrown when arguments are bad</exception>
type Quantizer<[<Measure>]'u>(minVal: float<'u>, maxVal: float<'u>, nSteps) =
    do
        if nSteps <= 1 || nSteps &&& (nSteps - 1) <> 0 then
            raise <| System.ArgumentException("Invalid number of discretization steps", "nSteps")
        if minVal >= maxVal then
            raise <| System.ArgumentException("Invalid discretization boundaries", "minVal, maxVal")

    let _interval = (maxVal - minVal) / float nSteps

/// <summary>Given a float value maps it to the correspondent integer
/// preserving the unit of measure</summary>
/// <param name="analog">Float value to be discretized</param>
/// <returns>Integer value to which the given input value maps</returns>
/// <exception cref="System.ArgumentOutOfRangeException">Thrown if argument does not within this Quantizer range</exception>
    member __.Discretize analog =
        if analog < minVal || analog > maxVal then
            raise <| System.ArgumentOutOfRangeException("analog")
        let digital = int ((analog - minVal)/_interval) in
            if digital = nSteps then digital - 1 else digital
        |> LanguagePrimitives.Int32WithMeasure<'u>
