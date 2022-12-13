const fs = require("fs")

const data = fs.readFileSync("input.txt", "utf-8")
let lines = data.split(/\r?\n/)
let sum = 0;
let packets = [[2],[6]]

for (let i = 0; i < lines.length; i++) {
    if (i % 3 !== 0) {
        continue
    }
    let line1 = lines[i]
    let line2 = lines[i + 1]
    packets.push(line1)
    packets.push(line2)
    console.log(lines[i])
    console.log(lines[i + 1])

    if (isValid(JSON.parse(line1), JSON.parse(line2))) {
        console.log(`Pair ${Math.ceil((i + 2) / 3)} in order`)
        sum += Math.ceil((i + 2) / 3)
    } else {
        console.log(`Pair ${Math.ceil((i + 2) / 3)} not in order`)
    }
    console.log()
}

console.log(sum)

function isValid(json1, json2) {
    let json1Array
    let json2Array

    if (json1 === undefined || json2 === undefined) return false

    if (!Array.isArray(json1)) {
        if (!Array.isArray(json2)) {
            return json1 < json2
        }
        json1Array = [json1]
        json2Array = json2
    } else if (!Array.isArray(json2)) {
        json1Array = json1
        json2Array = [json2]
    } else {
        json1Array = json1
        json2Array = json2
    }


    for (let i = 0; i < json1Array.length; i++) {
        if (isValid(json1Array[i], json2Array[i])) {
            return true
        } else if (isValid(json1Array[i], json2Array[i]) === null) {
            continue
        } else {
            if (json1Array[i] !== json2Array[i]) {
                return false
            }
        }
    }

    if (json1Array.length < json2Array.length) {
        return true
    } else if (json1Array.length === json2Array.length) {
        return null
    }

    return false
}