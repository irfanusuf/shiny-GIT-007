npm create vite@latest
name
react select
javascript




inside the project folder


npm i 
npm run dev



const [store, setStore] = useState({
    user : {},
    darkMode: false,
    loading: false,
    pics: [],
    orders : [],
    products : [],
    address : {}
  });




for updation of store 

    // setStore((prev) => ({ ...prev, darkMode: !store.darkMode }));

    
    // setStore ((prev) => ({...prev , loading :true}))
    // setStore((prev) => ({ ...prev, pics: res.data.photos, loading: false }));   // ensures state immutabilty


 npx create-react-app p7_reactjs_redux