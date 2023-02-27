
let items = [
    { content: 'my first widget' }, // will default to location (0,0) and 1x1
    { w: 2, content: 'another longer widget!' } // will be placed next at (1,0) and 2x1
];

let grid = GridStack.init({
    minRow: 1
});


document.onload = loadLayout();


function addWidget() {
    grid.addWidget(
        { x: 0, y: 0, w: 4, h:2, content: '<div class="card"><div class="card-body"><h5 class="card-title">Widget Title</h5><p class="card-text">With supporting text below as a natural lead-in to additional content.</p><a href="#" class="btn btn-primary">Go somewhere/Do something</a></div></div>' }
    );
};

function saveLayout() {
    serializedData = grid.save();
    localStorage.setItem("grid-layout", JSON.stringify(serializedData, null, '  '));
    console.log("Data saved: ", serializedData);
}

function loadLayout() {
    serializedData = localStorage.getItem("grid-layout");
    console.log("load serializedData", serializedData);
    let layout = JSON.parse(serializedData);
    console.log(layout);
    grid.load(layout, true);
    
}