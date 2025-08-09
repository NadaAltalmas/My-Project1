const jsonStringNada = '{"name": "Nada", "age": 20, "isStudent": false}';
let jsonObject = JSON.parse(jsonStringNada);

console.log(jsonObject);
console.log(jsonObject.name);
console.log(jsonObject.age);

const student = 
{
    name: "Bob",
    age: 21,
    isEnrolled: true,
    courses: ["Math", "Science", "Art"]
};

const jsonStringBob = JSON.stringify(student);
console.log(jsonStringBob);