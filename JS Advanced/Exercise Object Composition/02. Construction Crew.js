function modify({weight, experience, levelOfHydrated, dizziness}){
    if (dizziness === true){
        levelOfHydrated += 0.1 * weight * experience;
        dizziness = false;
    }

    return {weight, experience, levelOfHydrated, dizziness};
}