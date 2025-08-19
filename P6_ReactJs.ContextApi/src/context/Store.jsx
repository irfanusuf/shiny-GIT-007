import { createContext, useContext, useReducer } from "react";

import { Reducer } from "./Reducer";
import { initialState } from "./State";

const Context = createContext();



export const Store = ({children}) => {

  const [state, dispatch] = useReducer(Reducer ,  initialState);

  return (
    <Context.Provider value={{state , dispatch}}>
      {children}
    </Context.Provider>
  );
};


// const {state , dispatch } = useContext(Context)

//custom hook 
export const useDispatch = () => useContext(Context);









