import { useRenderIcon } from "@/components/ReIcon/src/hooks";
import Collection from "@iconify-icons/ep/money";

const Layout = () => import("@/layout/index.vue");

export default {
  path: "/asset",
  name: "asset",
  component: Layout,
  redirect: "/asset",
  meta: {
    icon: useRenderIcon(Collection),
    title: "资产管理",
    permissions: ["asset"],
    rank: 0
  },
  children: [
    {
      path: "/asset/query",
      name: "asset_query",
      meta: {
        title: "资产查询",
        permissions: ["asset.query"]
        //showParent: true
      },
      component: () => import("@/views/asset/query/index.vue")
    },
    {
      path: "/asset/type",
      name: "asset_type",
      meta: {
        title: "资产分类",
        permissions: ["asset.type"]
        //showParent: true
      },
      component: () => import("@/views/asset/type/index.vue")
    },
    {
      path: "/asset/list",
      name: "asset_list",
      meta: {
        title: "资产列表",
        permissions: ["asset.list"]
        //showParent: true
      },
      component: () => import("@/views/asset/list/index.vue")
    }
  ]
} as RouteConfigsTable;
