namespace day1;

public static class trebuchet_calibrator{
    public static int calibrate(StreamReader sr){
        string line;
        
        int calibration_sum = 0;
        while ((line = sr.ReadLine()) != null){
            char[] digits = new char[2];

            for (int i=0 ; i<line.Length ; i++){
                if (char.IsDigit(line[i])){
                    digits[0] = line[i];
                    break;
                }
            }
            for (int i=line.Length-1 ; i>=0 ; i--){
                if (char.IsDigit(line[i])){
                    digits[1] = line[i];
                    break;
                }
            }
            

            if (int.TryParse(new string(digits), out var current_calibration)){
                calibration_sum += current_calibration;
            }else{
                throw new InvalidOperationException("couldn't parse digits");
            }
        }

        return calibration_sum;
    }
}
