

  export function Reducer(state, action) {

    switch (action.type) {

      case "TOGGLE_DARK_MODE":
        return { ...state, darkMode: !state.darkMode };

      case "SET_LOADING":
        return { ...state, loading: action.payload };

      case "SET_PICS":
        return { ...state, pics: action.payload };

      case "SET_USER":
        return { ...state, user: action.payload };

      case "SET_ORDERS":
        return { ...state, orders: action.payload };

      case "SET_PRODUCTS":
        return { ...state, products: action.payload };

      case "SET_ADDRESS":
        return { ...state, address: action.payload };

      default:
        return state;
    }
  }
